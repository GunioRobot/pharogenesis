isDone
	"Returns true if the alarm has expired."

	^ (myScheduler getTime) > alarmTime.
