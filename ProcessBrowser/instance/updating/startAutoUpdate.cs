startAutoUpdate
	self isAutoUpdatingPaused ifTrue: [ ^autoUpdateProcess resume ].
	self isAutoUpdating
		ifFalse: [| delay | 
			delay _ Delay forSeconds: 2.
			autoUpdateProcess _ [[self hasView]
						whileTrue: [delay wait.
							deferredMessageRecipient ifNotNil: [
								deferredMessageRecipient addDeferredUIMessage: [self updateProcessList]]
							ifNil: [ self updateProcessList ]].
					autoUpdateProcess _ nil] fork].
	self updateProcessList