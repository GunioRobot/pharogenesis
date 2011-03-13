controllerSatisfying: aBlock
	"Return the first scheduled controller which satisfies the 1-argument boolean-valued block, or nil if none.  7/25/96 sw"

	scheduledControllers do:
		[:aController | (aBlock value: aController) == true ifTrue: [^ aController]].
	^ nil