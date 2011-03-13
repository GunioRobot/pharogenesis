doButtonUpAction

	(target ~~ nil and: [actionUpSelector ~~ nil]) ifTrue: [
		Cursor normal showWhile: [
			target perform: actionUpSelector]].