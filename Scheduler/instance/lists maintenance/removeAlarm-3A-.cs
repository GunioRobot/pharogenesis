removeAlarm: anAlarm
	"Remove an alarm from the Scheduler's list of alarms"

	alarmList remove: anAlarm ifAbsent: [].
