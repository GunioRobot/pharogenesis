forDoit: aString
	^ (self subclassForDoit: aString) ifNotNilDo: [:c | c new source: aString]