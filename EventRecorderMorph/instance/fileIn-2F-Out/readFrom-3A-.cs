readFrom: aStream
	"Private"
	| cr t evt line lineStream |
	cr _ Character cr.
	tape _ Array streamContents:
		[:tStream |
		[aStream atEnd] whileFalse:
			[line _ aStream upTo: cr.
			line isEmpty "Some MW tapes have an empty record at the end"
				ifFalse: [lineStream _ ReadStream on: line.
						t _ Integer readFrom: lineStream.
						[lineStream peek isLetter] whileFalse: [lineStream next].
						evt _ MorphicEvent readFrom: lineStream.
						tStream nextPut: t -> evt]]].
	saved _ true  "Still exists on file"