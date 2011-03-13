tempsAndValues
	"Return a string of the temporary variabls and their current values"
	| aStream |
	aStream _ WriteStream on: (String new: 100).
	self tempNames
		doWithIndex: [:title :index |
			aStream nextPutAll: title; nextPut: $:; space; tab.
			(self tempAt: index) printOn: aStream.
			aStream cr].
	^aStream contents