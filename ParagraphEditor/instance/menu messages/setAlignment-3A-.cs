setAlignment: aSymbol
	| attr interval |
	attr _ TextAlignment perform: aSymbol.
	interval _ self encompassLine: self selectionInterval.
	paragraph replaceFrom: interval first to: interval last with:
		((paragraph text copyFrom: interval first to: interval last) addAttribute: attr) displaying: true.