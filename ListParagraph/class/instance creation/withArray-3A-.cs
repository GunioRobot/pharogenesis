withArray: anArray
	"Convert an array of strings into a ListParagraph."

	^ (super withText: Text new style: ListStyle) withArray: anArray