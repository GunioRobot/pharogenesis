do: task in: waitTime inScheduler: scheduler
	"This sets an alarm that will expire in waitTime seconds and execute the specified task"

	| newAlarm |
	newAlarm _ AliceAlarm new.

	newAlarm setTask: task.
	newAlarm setTime: waitTime + (scheduler getTime).
	newAlarm setScheduler: scheduler.

	scheduler addAlarm: newAlarm.

	^ newAlarm.
