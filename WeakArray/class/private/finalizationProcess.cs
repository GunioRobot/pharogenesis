finalizationProcess

	[true] whileTrue:
		[FinalizationSemaphore wait.
		FinalizationLock critical:
			[FinalizationDependents do:
				[:weakDependent |
				weakDependent ifNotNil:
					[weakDependent finalizeValues.
					"***Following statement is required to keep weakDependent
					from holding onto its value as garbage.***"
					weakDependent _ nil]]]
			ifError:
			[:msg :rcvr | rcvr error: msg].
		].
