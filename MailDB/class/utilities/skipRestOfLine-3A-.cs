skipRestOfLine: aStream
	"Consume characters from the given stream through the next carriage return."

	| crValue |
	crValue _ Character cr asciiValue.
	[aStream atEnd or:
	 [aStream next asciiValue == crValue]] whileFalse:
		["consume until end of stream or a carriage return"].