do: task eachframeuntil: condition toObject: anObject inScheduler: scheduler
	"Creates a new Action that performs the specified task each frame until the specified condition holds true"

	| newAction |
	newAction _ Action new.

	newAction setTask: task.
	newAction setLifetime: -1 andCondition: condition.
	newAction setAffectedObject: anObject.
	newAction setScheduler: scheduler.

	scheduler addAction: newAction.

	^ newAction.
