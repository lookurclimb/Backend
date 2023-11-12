using AutoMapper;
using LevelUpCenter.Coaching.Domain.Models;
using LevelUpCenter.Coaching.Resources;
using LevelUpCenter.Coaching.Resources.Coach;
using LevelUpCenter.Coaching.Resources.Course;
using LevelUpCenter.Coaching.Resources.Game;
using LevelUpCenter.Coaching.Resources.Learner;

namespace LevelUpCenter.Coaching.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Publication, PublicationResource>();
        // Games
        CreateMap<Game, SaveGameResource>();
        CreateMap<Game, UpdateGameResource>();
        CreateMap<Game, GameResource>();

        CreateMap<Course, CourseResource>();

        // Coaches
        CreateMap<Coach, SaveCoachResource>();
        CreateMap<Coach, CoachResource>();

        // Learners
        CreateMap<Learner, SaveLearnerResource>();
        CreateMap<Learner, LearnerResource>();
    }
}
