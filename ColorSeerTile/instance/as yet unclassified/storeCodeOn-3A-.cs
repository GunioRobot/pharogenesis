storeCodeOn: aStream
	"We have a hidden arg.  Give 'keyword1: arg1 keyword2:' as my operator string" 
	
	| parts |
	parts _ operatorOrExpression keywords.	"color:sees:"
	^ aStream nextPutAll: (parts at: 1); space;
		nextPutAll: colorSwatch color printString; space;
		nextPutAll: (parts at: 2).
	
