helpText

	helpText ifNil:
		[helpText _ PluggableTextMorph new
			width: self width; "board width;"
			editString: self helpString].
	^ helpText