quickLoadEngineFrom: oop requiredState: requiredState
	self inline: false.
	(self quickLoadEngineFrom: oop) ifFalse:[^false].
	self stateGet = requiredState ifTrue:[^true].
	self stopReasonPut: GErrorBadState.
	^false