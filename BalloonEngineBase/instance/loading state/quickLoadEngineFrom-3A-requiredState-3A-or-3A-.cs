quickLoadEngineFrom: oop requiredState: requiredState or: alternativeState
	self inline: false.
	(self quickLoadEngineFrom: oop) ifFalse:[^false].
	self stateGet = requiredState ifTrue:[^true].
	self stateGet = alternativeState ifTrue:[^true].
	self stopReasonPut: GErrorBadState.
	^false