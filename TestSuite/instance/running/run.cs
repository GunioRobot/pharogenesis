run
	| result |
 	result := TestResult new.
	self resources do: [ :res |
		res isAvailable ifFalse: [^res signalInitializationError]].
	[self run: result] sunitEnsure: [self resources do: [:each | each reset]].
	^result
			