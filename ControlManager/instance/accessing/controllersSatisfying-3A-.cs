controllersSatisfying: aBlock
	"Return a list of scheduled controllers satisfying aBlock.  "

	^ scheduledControllers select:
		[:aController | (aBlock value: aController) == true]