do: task eachframefor: time toObject: anObject inScheduler: scheduler
	"Creates a new Action that performs the specified task each frame for (time) seconds"

	| newAction |
	newAction _ Action new.

	newAction setTask: task.
	newAction setLifetime: (time + (scheduler getTime)) andCondition: [false].
	newAction setAffectedObject: anObject.
	newAction setScheduler: scheduler.

	scheduler addAction: newAction.

	^ newAction.
