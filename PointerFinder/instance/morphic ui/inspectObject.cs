inspectObject
	pointerListIndex = 0 ifTrue: [^ self beep].
	(objectList at: pointerListIndex) inspect