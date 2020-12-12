using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;
using PSK.SmartGarden.Data.Input;

namespace PSK.SmartGarden.Data.Repository
{
    class MongoMeasurementRepository : IMeasurementRepository
    {
        private readonly IMongoCollection<MeasurementEntity> _measurements;

        public MongoMeasurementRepository(IGardenDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _measurements = database.GetCollection<MeasurementEntity>(settings.MeasurementsCollectionName);
        }

        public IList<MeasurementEntity> GetMeasurementList(GetMeasurementListInput input, out long totalCount)
        {
            FilterDefinition<MeasurementEntity> filter = FilterDefinition<MeasurementEntity>.Empty;

            if (input.From.HasValue)
            {
                filter = Builders<MeasurementEntity>.Filter.And(filter,
                    Builders<MeasurementEntity>.Filter.Gte(x => x.Date, input.From));
            }

            if (input.To.HasValue)
            {
                filter = Builders<MeasurementEntity>.Filter.And(filter,
                    Builders<MeasurementEntity>.Filter.Lte(x => x.Date, input.To));
            }

            var cursor = _measurements.Find(filter);

            totalCount = cursor.CountDocuments();

            if (input.PageNumber.HasValue && input.PageSize.HasValue)
            {
                cursor = cursor
                    .Skip((input.PageNumber - 1) * input.PageSize)
                    .Limit(input.PageSize);
            }

            if (input.SortType != null)
            {
                Expression<Func<MeasurementEntity, object>> GetSortExpression()
                {
                    switch (input.SortType)
                    {
                        case GetMeasurementListInput.Sort.Date:
                            return x => x.Date;

                        case GetMeasurementListInput.Sort.AirHumidity:
                            return x => x.AirHumidity;

                        case GetMeasurementListInput.Sort.AirTemperature:
                            return x => x.AirTemperature;

                        case GetMeasurementListInput.Sort.SoilMoisture:
                            return x => x.SoilMoisture;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                SortDefinition<MeasurementEntity> sort = input.SortDirection == SortDirection.Asc
                    ? Builders<MeasurementEntity>.Sort.Ascending(GetSortExpression())
                    : Builders<MeasurementEntity>.Sort.Descending(GetSortExpression());

                cursor = cursor.Sort(sort);
            }

            return cursor.ToList();
        }
    }
}