update: currentTime
	"If the alarm's time has expired, then execute the task associated with the alarm."

	(alarmTime < currentTime)
			ifTrue:	[ self execute ].


