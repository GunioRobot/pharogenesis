do: task toObject: anObject inScheduler: scheduler
	"Creates a new Action that executes the specified task each frame"

	| newAction |
	newAction _ Action new.

	newAction setTask: task.
	newAction setLifetime: -1 andCondition: [false].
	newAction setAffectedObject: anObject.
	newAction setScheduler: scheduler.

	scheduler addAction: newAction.

	^ newAction.
