textEntryFieldNamed: aSymbol with: aString help: helpString

	| f col |
	f _ (StringMorph new contents: aString)
		setBalloonText: helpString;
		on: #mouseUp send: #editEvent:for: to: self.
	self field: aSymbol is: f.
	col _ (self inAColumn: {f}) color: Color white; hResizing: #shrinkWrap.
	^col