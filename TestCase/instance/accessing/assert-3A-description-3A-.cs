assert: aBoolean description: aString
	aBoolean ifFalse: [
		self logFailure: aString.
		TestResult failure sunitSignalWith: aString]
			