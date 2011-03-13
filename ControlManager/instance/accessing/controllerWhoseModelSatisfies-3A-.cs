controllerWhoseModelSatisfies: aBlock
	"Return the first scheduled controller whose model satisfies the 1-argument boolean-valued block, or nil if none.  5/6/96 sw"

	scheduledControllers do:
		[:aController | (aBlock value: aController model) == true ifTrue: [^ aController]].
	^ nil