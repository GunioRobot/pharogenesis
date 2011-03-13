callTempCommand
	argument
		ifNotNil:
			[argument tempCommand]
		ifNil:
			[self world tempCommand]