withArray: anArray lineSpacing: spacing
	"Convert an array of strings into a ListParagraph."
	^ (super new gridWithLead: spacing) withArray: anArray