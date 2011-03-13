adjustAlarmTimes: nowTime
	"Adjust the alarm times after some clock weirdness (such as roll-over, image-startup etc)"
	| deltaTime |
	deltaTime _ nowTime - lastAlarmTime.
	self alarms do:[:alarm| alarm scheduledTime: alarm scheduledTime + deltaTime].