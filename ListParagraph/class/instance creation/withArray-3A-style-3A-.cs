withArray: anArray style: aTextStyleOrNil
	"Convert an array of strings into a ListParagraph using the given TextStyle."

	aTextStyleOrNil
		ifNil: [^ (super withText: Text new style: ListStyle) withArray: anArray]
		ifNotNil: [^ (super withText: Text new style: aTextStyleOrNil) withArray: anArray].
