exceptions
	"Handle some very slippery selectors.
	asSymbol -- want to be able to produce it, but do not want to make every string submitted into a Symbol!" 

	| aSel |
	answers first class == Symbol ifFalse: [^ self].
	thisData first first class == String ifFalse: [^ self].
	aSel _ #asSymbol.
	(self testPerfect: aSel) ifTrue: [
		selector add: aSel.
		expressions nextPut: $(.
		expressions nextPutAll: 'data', argMap first printString.
		aSel keywords doWithIndex: [:key :ind |
			expressions nextPutAll: ' ',key.
			(key last == $:) | (key first isLetter not)
				ifTrue: [expressions nextPutAll: ' data', 
					(argMap at: ind+1) printString]].
		expressions nextPut: $); space].
