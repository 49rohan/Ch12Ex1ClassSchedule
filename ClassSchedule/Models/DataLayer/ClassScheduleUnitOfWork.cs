namespace ClassSchedule.Models
{
    public class ClassScheduleUnitOfWork : IClassScheduleUnitOfWork
    {
        private readonly ClassScheduleContext _context;

        public ClassScheduleUnitOfWork(ClassScheduleContext context)
        {
            _context = context;
        }

        private Repository<Class> _classRepository;
        private Repository<Teacher> _teacherRepository;
        private Repository<Day> _dayRepository;

        public Repository<Class> Classes
        {
            get
            {
                if (_classRepository == null)
                {
                    _classRepository = new Repository<Class>(_context);
                }
                return _classRepository;
            }
        }

        public Repository<Teacher> Teachers
        {
            get
            {
                if (_teacherRepository == null)
                {
                    _teacherRepository = new Repository<Teacher>(_context);
                }
                return _teacherRepository;
            }
        }

        public Repository<Day> Days
        {
            get
            {
                if (_dayRepository == null)
                {
                    _dayRepository = new Repository<Day>(_context);
                }
                return _dayRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}