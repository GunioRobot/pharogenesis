doButtonDownAction

	(target ~~ nil and: [actionDownSelector ~~ nil]) ifTrue: [
		Cursor normal showWhile: [
			target perform: actionDownSelector]].