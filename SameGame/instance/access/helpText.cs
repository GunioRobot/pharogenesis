helpText

	helpText ifNil:
		[helpText _ PluggableTextMorph new
			width: board width;
			editString: self helpString].
	^ helpText