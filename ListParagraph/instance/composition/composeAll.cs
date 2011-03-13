composeAll
	"No composition is necessary once the ListParagraph is created."
	
	lastLine isNil ifTrue: [lastLine _ 0].	
		"Because composeAll is called once in the process of creating the ListParagraph."
	^compositionRectangle width