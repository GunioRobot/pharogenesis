parseFileNamed: aString
	"Read the 3DS file from the given stream"
	| s f |
	f _ FileStream readOnlyFileNamed: aString.
	f binary.
	'Reading 3DS file ', aString  displayProgressAt: Sensor cursorPoint
		from: 0 to: f size during:[:bar|
			self informer: bar.
			s _ self parseStream: f.
		].
	f close.
	^s