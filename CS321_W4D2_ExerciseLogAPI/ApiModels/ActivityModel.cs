using System;
namespace CS321_W4D2_ExerciseLogAPI.ApiModels
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int ActivityTypeId { get; set; }
        // TODO: Make ActivityType a string property that will contain the name of the activity type (update the mapping code)
        //public ActivityType ActivityType { get; set; }

        public double Duration { get; set; }
        public double Distance { get; set; }

        public int UserId { get; set; }
        // TODO: Make User a string property that will contain the User's name (updating the mapping code)
        //public User User { get; set; }

        public string Notes { get; set; }
    }
}
