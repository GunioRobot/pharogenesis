newParagraph: aParagraph 
	"Answer an instance of me with aParagraph as the text to be edited."

	| aParagraphEditor |
	aParagraphEditor _ super new.
	aParagraphEditor initialize.
	aParagraphEditor changeParagraph: aParagraph.
	^aParagraphEditor