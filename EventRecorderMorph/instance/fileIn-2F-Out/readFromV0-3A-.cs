readFromV0: aStream
	| cr line lineStream t evt |
	cr _ Character cr.
	^Array streamContents:[:tStream |
		[aStream atEnd] whileFalse:
			[line _ aStream upTo: cr.
			line isEmpty "Some MW tapes have an empty record at the end"
				ifFalse: [lineStream _ ReadStream on: line.
						t _ Integer readFrom: lineStream.
						[lineStream peek isLetter] whileFalse: [lineStream next].
						evt _ MorphicEvent readFromObsolete: lineStream.
						tStream nextPut: t -> evt]]].