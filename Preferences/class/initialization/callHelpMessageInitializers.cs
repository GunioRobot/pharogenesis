callHelpMessageInitializers
	| listOfPairs |
	"Preferences callHelpMessageInitializers"
	(self class organization listAtCategoryNamed: #help) do:
		[:aSelector | aSelector numArgs = 0 ifTrue:
			[((listOfPairs _ self perform: aSelector) isKindOf: Collection)
				ifTrue:
					[listOfPairs do:
						[:pair | HelpDictionary at: pair first put: 
					(pair first, ':
		', pair last)]]]]