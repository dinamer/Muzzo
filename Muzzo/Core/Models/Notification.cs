using System;

namespace Muzzo.Main.Models
{
    public class Notification
    {
        public int Id { get; private set; }

        public int GigId { get; private set; }
        public Gig Gig { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; private set; }

        public string OriginalVenue { get; private set; }


        //Constructors
        protected Notification()
        {

        }

        protected Notification(Gig gig, NotificationType type)
        {
            if (gig == null)
                throw new ArgumentNullException("gig");

            Gig = gig;
            DateTime = DateTime.Now;
            Type = type;
        }

        protected Notification(Gig gig, NotificationType type, DateTime originalDateTime, string originalVenue)
        {
            if (gig == null)
                throw new ArgumentNullException("gig");

            if (originalDateTime == null)
                throw new ArgumentNullException("originalDateTime");

            if (originalVenue == null)
                throw new ArgumentNullException("originalVenue");

            Gig = gig;
            DateTime = DateTime.Now;
            Type = type;
            OriginalDateTime = originalDateTime;
            OriginalVenue = originalVenue;
        }


        //Factory methods
        public static Notification GigAdded(Gig gig)
        {
            return new Notification(gig, NotificationType.GigAdded);

        }

        public static Notification GigUpdated(Gig gig, DateTime originalDateTime, string originalVenue)
        {
            return new Notification(gig, NotificationType.GigUpdated, originalDateTime, originalVenue);

        }

        public static Notification GigCanceled(Gig gig)
        {
            return new Notification(gig, NotificationType.GigCanceled);
        }

    }
}