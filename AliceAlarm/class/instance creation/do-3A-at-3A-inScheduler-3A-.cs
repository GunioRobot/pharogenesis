do: task at: executeTime inScheduler: scheduler
	"Creates an alarm that does the specified task at the specified time"

	| newAlarm |
	newAlarm _ AliceAlarm new.

	newAlarm setTime: executeTime.
	newAlarm setTask: task.
	newAlarm setScheduler: scheduler.

	scheduler addUpdateItem: newAlarm.

	^ newAlarm.