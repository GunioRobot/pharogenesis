defaultSelector 
	"Invent and answer an appropriate message selector (a 
	Symbol) for me, that is, one that will parse with the correct number of 
	arguments."

	| aStream |
	aStream _ WriteStream on: (String new: 16).
	aStream nextPutAll: 'DoIt'.
	1 to: self numArgs do: [:i | aStream nextPutAll: 'with:'].
	^aStream contents asSymbol