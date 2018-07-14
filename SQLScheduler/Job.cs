using System;

namespace SQLScheduler
{
    class Job
    {

        public string name;
        public string description;
        public Boolean oneTime;
        public int recurringTime;
        public string recurringPeriod;
        public DateTime startingTime;
        public DateTime endingTime;
        public DateTime lastExecute;
        public DateTime nextExecute;
        public string sqlQuery;
        public Boolean enabled;
        
        public Job()
        {
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }
        public void setOneTime(Boolean oneTime)
        {
            this.oneTime = oneTime;
        }
        public void setRecurringTime(int recurringTime)
        {
            this.recurringTime = recurringTime;
        }
        public void setRecurringPeriod(string recurringPeriod)
        {
            this.recurringPeriod = recurringPeriod;
        }
        public void setStartingTime(DateTime startingTime)
        {
            this.startingTime = startingTime;
        }
        public void setEndingTime(DateTime endingTime)
        {
            this.endingTime = endingTime;
        }
        public void setSqlQuery(string sqlQuery)
        {
            this.sqlQuery = sqlQuery;
        }
        public void setLastExecute(DateTime lastExecute)
        {
            this.lastExecute = lastExecute;
        }
        public void setNextExecute(DateTime nextExecute)
        {
            this.nextExecute = nextExecute;
        }
        public void setEnabled(Boolean enabled)
        {
            this.enabled = enabled;
        }

        public string getName()
        {
            return name;
        }
        public string getDescription()
        {
            return description;
        }
        public Boolean getOneTime()
        {
            return oneTime;
        }
        public int getRecurringTime()
        {
            return recurringTime;
        }
        public string getRecurringPeriod()
        {
            return recurringPeriod;
        }
        public DateTime getStartingTime()
        {
            return startingTime;
        }
        public DateTime getEndingTime()
        {
            return endingTime;
        }
        public string getSqlQuery()
        {
            return sqlQuery;
        }
        public DateTime getLastExecute()
        {
            return lastExecute;
        }
        public DateTime getNextExecute()
        {
            return nextExecute;
        }
        public Boolean getEnabled()
        {
            return enabled;
        }

    }
}
