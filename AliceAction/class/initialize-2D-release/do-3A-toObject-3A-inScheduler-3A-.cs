do: task toObject: anObject inScheduler: scheduler
	"Creates a new AliceAction that executes the specified task each frame"

	| newAction |
	newAction _ AliceAction new.

	newAction setTask: task.
	newAction setLifetime: -1 andCondition: [false].
	newAction setAffectedObject: anObject.
	newAction setScheduler: scheduler.

	scheduler addUpdateItem: newAction.

	^ newAction.
