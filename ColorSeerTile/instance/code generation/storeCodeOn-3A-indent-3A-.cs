storeCodeOn: aStream indent: tabCount
	"We have a hidden arg. Output two keywords with interspersed arguments."

	| parts |
	parts _ operatorOrExpression keywords.	"color:sees:"
	^ aStream nextPutAll: (parts at: 1); space;
		nextPutAll: colorSwatch color printString; space;
		nextPutAll: (parts at: 2).
