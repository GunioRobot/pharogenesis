removeSelection

	selection ifNil: [^ self].
	self rememberUndoableAction: 
			[selection do: [:loc | (self tileAt: loc) disabled: true; setSwitchState: false].
			self collapseColumns: (selection collect: [:loc | loc x]) asSet asSortedCollection.
			selection _ nil.
			flash _ false.
			(target ~~ nil and: [actionSelector ~~ nil])
				ifTrue: [target perform: actionSelector withArguments: arguments]]
		named: 'remove selection'
