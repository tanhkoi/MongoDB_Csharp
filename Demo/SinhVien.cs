using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo
{
    internal class SinhVien
    {
        [BsonId, BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("hoTen"), BsonRepresentation(BsonType.String)]
        public string hoTen { get; set; }

        [BsonElement("MSSV"), BsonRepresentation(BsonType.Int32)]
        public int MSSV { get; set; }

        [BsonElement("noiSong"), BsonRepresentation(BsonType.String)]
        public string noiSong { get; set; }

    }
}
