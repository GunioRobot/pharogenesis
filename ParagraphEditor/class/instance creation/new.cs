new
	"Answer a new instance of me with a null Paragraph to be edited."

	| aParagraphEditor |
	aParagraphEditor _ super new.
	aParagraphEditor changeParagraph: '' asParagraph.
	^aParagraphEditor