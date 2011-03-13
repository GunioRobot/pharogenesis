screenDump
	| form f |
	form _ Form fromDisplay: Display boundingBox.
	f _ FileStream fileNamed: 'STScreen', Time millisecondClockValue printString.
	form bigMacPaintOn: f.
	f close

"Form screenDump"