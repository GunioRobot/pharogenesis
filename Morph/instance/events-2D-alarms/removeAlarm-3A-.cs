removeAlarm: aSelector
	"Remove the given alarm"
	| scheduler |
	scheduler _ self alarmScheduler.
	scheduler ifNotNil:[scheduler removeAlarm: aSelector for: self].