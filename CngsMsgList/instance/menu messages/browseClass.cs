browseClass
	controller controlTerminate.
	self classAndSelectorDo:
		[:cl :sel |  
		Browser postOpenSuggestion: 
			(Array with: cl with: sel).
		Browser newOnClass: cl].
	controller controlInitialize