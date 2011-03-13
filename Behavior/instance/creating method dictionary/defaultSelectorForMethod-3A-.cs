defaultSelectorForMethod: aMethod 
	"Given a method, invent and answer an appropriate message selector (a 
	Symbol), that is, one that will parse with the correct number of 
	arguments."

	| aStream |
	aStream _ WriteStream on: (String new: 16).
	aStream nextPutAll: 'DoIt'.
	1 to: aMethod numArgs do: [:i | aStream nextPutAll: 'with:'].
	^aStream contents asSymbol