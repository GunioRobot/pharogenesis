performActionSelector: actionSymbol

	(target ~~ nil and: [actionSelector ~~ nil]) ifTrue: [
		target perform: actionSelector with: actionSymbol].