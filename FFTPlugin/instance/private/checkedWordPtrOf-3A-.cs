checkedWordPtrOf: oop
	"Return the first indexable word of oop which is assumed to be variableWordSubclass"
	self returnTypeC:'unsigned int *'.
	interpreterProxy success: (interpreterProxy isWords: oop).
	^self cCoerce: (interpreterProxy firstIndexableField: oop) to: 'unsigned int *'