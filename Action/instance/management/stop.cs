stop
	"This method removes the Action from myScheduler's list of active actions"

	stopCondition _ [ true ].
	myScheduler removeAction: self.
