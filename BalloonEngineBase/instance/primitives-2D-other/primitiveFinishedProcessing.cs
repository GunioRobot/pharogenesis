primitiveFinishedProcessing
	| finished |
	self export: true.
	self inline: false.
	doProfileStats ifTrue:[geProfileTime _ interpreterProxy ioMicroMSecs].
	interpreterProxy methodArgumentCount = 0
		ifFalse:[^interpreterProxy primitiveFail].
	engine _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(self quickLoadEngineFrom: engine)
		ifFalse:[^interpreterProxy primitiveFail].
	finished _ self finishedProcessing.
	self storeEngineStateInto: engine.
	interpreterProxy pop: 1.
	interpreterProxy pushBool: finished.
	doProfileStats ifTrue:[
		self incrementStat: GWCountFinishTest by: 1.
		self incrementStat: GWTimeFinishTest by: (interpreterProxy ioMicroMSecs - geProfileTime)].
