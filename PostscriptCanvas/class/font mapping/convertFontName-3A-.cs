convertFontName: aName
	"Break apart aName on case boundaries, inserting hyphens as needed."
	| lastCase |
	lastCase _ aName first isUppercase.
	^ String streamContents: [ :s |
		aName do: [ :c | | thisCase |
			thisCase _ c isUppercase.
			(thisCase and: [ lastCase not ]) ifTrue: [ s nextPut: $- ].
			lastCase _ thisCase.
			s nextPut: c ]]