tileClickedAt: location newSelection: isNewSelection

	| tile |
	isNewSelection
		ifTrue:
			[self deselectSelection.
			tile _ self tileAt: location.
			selectionColor _ tile color.
			selection _ OrderedCollection with: location.
			self selectTilesAdjacentTo: location.
			selection size = 1
				ifTrue: [self deselectSelection]
				ifFalse:
					[(target ~~ nil and: [actionSelector ~~ nil])
					ifTrue: [target perform: actionSelector withArguments: arguments]]]
		ifFalse:
			[self removeSelection].