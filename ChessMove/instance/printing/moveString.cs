moveString
	^String streamContents:[:aStream|
		aStream nextPutAll: (#('' 'N' 'B' 'R' 'Q' 'K') at: movingPiece).
		aStream nextPutAll: (String with: ($a asInteger + (sourceSquare - 1 bitAnd: 7)) asCharacter with: ($1 asInteger + (sourceSquare -1 bitShift: -3)) asCharacter).
		capturedPiece = 0 ifTrue:[
			aStream nextPutAll: '-'.
		] ifFalse:[
			aStream nextPutAll: 'x'.
			aStream nextPutAll: (#('' 'N' 'B' 'R' 'Q' 'K') at: capturedPiece).
		].
		aStream nextPutAll: (String with: ($a asInteger + (destinationSquare - 1 bitAnd: 7)) asCharacter with: ($1 asInteger + (destinationSquare -1 bitShift: -3)) asCharacter).
	].