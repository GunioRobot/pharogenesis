debug
	self resources do: [:res | 
		res isAvailable ifFalse: [^res signalInitializationError]].
	[(self class selector: testSelector) runCase] 
		sunitEnsure: [self resources do: [:each | each reset]]
			