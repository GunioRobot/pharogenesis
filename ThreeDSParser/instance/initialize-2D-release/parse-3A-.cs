parse: aStream
	"Read the 3DS file from the given stream"
	| s |
	'Reading 3DS file' displayProgressAt: Sensor cursorPoint
		from: 0 to: aStream size during:[:bar|
			self informer: bar.
			s _ self parseStream: aStream.
	].
	^s