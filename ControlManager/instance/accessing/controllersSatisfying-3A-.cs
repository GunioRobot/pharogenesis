controllersSatisfying: aBlock
	"Return a list of scheduled controllers satisfying aBlock"

	^ (scheduledControllers ifNil: [^ #()]) select:
		[:aController | (aBlock value: aController) == true]