updateTargetColor

	((target ~~ nil) and: [selector ~~ nil]) ifTrue: [
		selector numArgs = 2
			ifTrue: [target perform: selector with: selectedColor with: sourceHand]
			ifFalse: [target perform: selector with: selectedColor]].
