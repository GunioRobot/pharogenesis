removeAction: anAction
	"Remove an action from the Scheduler's list of actions"

	actionList remove: anAction ifAbsent: [].
