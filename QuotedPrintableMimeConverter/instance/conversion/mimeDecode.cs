mimeDecode
	"Do conversion reading from mimeStream writing to dataStream"

	| line s c1 v1 c2 v2 |
	[(line _ mimeStream nextLine) isNil] whileFalse: [
		line _ line withoutTrailingBlanks.
		line size = 0
			ifTrue: [dataStream cr]
			ifFalse: [
				s _ ReadStream on: line.
				[dataStream nextPutAll: (s upTo: $=).
				s atEnd] whileFalse: [
					c1 _ s next. v1 _ c1 digitValue.
					((v1 between: 0 and: 15) and: [s atEnd not])
						ifFalse: [dataStream nextPut: $=; nextPut: c1]
						ifTrue: [c2 _ s next. v2 _ c2 digitValue.
							(v2 between: 0 and: 15)
								ifFalse: [dataStream nextPut: $=; nextPut: c1; nextPut: c2]
								ifTrue: [dataStream nextPut: (Character value: v1 * 16 + v2)]]].
				line last = $= ifFalse: [dataStream cr]]].
	^ dataStream