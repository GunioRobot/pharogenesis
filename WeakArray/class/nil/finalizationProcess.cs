finalizationProcess

	[true] whileTrue:
		[FinalizationSemaphore wait.
		FinalizationLock critical:
			[FinalizationDependents do:
				[:weakDependent |
				weakDependent ifNotNil:
					[weakDependent finalizeValues]]]
			ifError:
			[:msg :rcvr | rcvr error: msg].
		].
