tileClickedAt: location newSelection: isNewSelection 
	| tile |
	isNewSelection 
		ifTrue: 
			[self deselectSelection.
			tile := self tileAt: location.
			selectionColor := tile color.
			selection := OrderedCollection with: location.
			self selectTilesAdjacentTo: location.
			selection size = 1 
				ifTrue: [self deselectSelection]
				ifFalse: 
					[(target notNil and: [actionSelector notNil]) 
						ifTrue: [target perform: actionSelector withArguments: arguments]]]
		ifFalse: [self removeSelection]