removeAlarm: aSelector at: scheduledTime
	"Remove the given alarm"
	| scheduler |
	scheduler _ self alarmScheduler.
	scheduler ifNotNil:[scheduler removeAlarm: aSelector at: scheduledTime for: self].