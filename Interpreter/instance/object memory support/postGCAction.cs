postGCAction
	"Mark the active and home contexts as roots if old. This allows the interpreter to use storePointerUnchecked to store into them."

	(activeContext    < youngStart) ifTrue: [ self beRootIfOld: activeContext ].
	(theHomeContext < youngStart) ifTrue: [ self beRootIfOld: theHomeContext ].
