finalizationProcess

	[true] whileTrue:[
		FinalizationSemaphore wait.
		FinalizationLock critical:[
			FinalizationDependents do:[:weakDependent|
				weakDependent isNil 
					ifFalse:[weakDependent finalizeValues].
			].
		] ifError:[:msg :rcvr| rcvr error: msg].
	].