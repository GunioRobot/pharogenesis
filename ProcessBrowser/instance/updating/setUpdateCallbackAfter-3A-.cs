setUpdateCallbackAfter: seconds

		deferredMessageRecipient ifNotNil: [ | d |
			d _ Delay forSeconds: seconds.
			[  d wait.
				d _ nil.
				deferredMessageRecipient addDeferredUIMessage: [self updateProcessList]
			] fork
		]