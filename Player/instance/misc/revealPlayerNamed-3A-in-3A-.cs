revealPlayerNamed: aSymbol in: aWorld 
	| getter |
	getter := Utilities getterSelectorFor: aSymbol.
	^ (self perform: getter)
		revealPlayerIn: aWorld