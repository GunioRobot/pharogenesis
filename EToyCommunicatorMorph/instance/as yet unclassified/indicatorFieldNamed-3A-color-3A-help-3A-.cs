indicatorFieldNamed: aSymbol color: aColor help: helpString

	| f col |
	f _ EllipseMorph new
		extent: 10@10;
		color: aColor;
		setBalloonText: helpString.
	self field: aSymbol is: f.
	col _ (self inAColumn: {f}) hResizing: #shrinkWrap.
	^col