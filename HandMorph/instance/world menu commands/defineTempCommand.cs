defineTempCommand
	argument
		ifNotNil:
			[argument defineTempCommand]
		ifNil:
			[self world defineTempCommand]