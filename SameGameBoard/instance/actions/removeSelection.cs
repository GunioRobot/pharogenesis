removeSelection
	selection
		ifNil: [^ self].
	self
		rememberUndoableAction: [selection
				do: [:loc | (self tileAt: loc) disabled: true;
						 setSwitchState: false].
			self collapseColumns: (selection
					collect: [:loc | loc x]) asSet asSortedCollection.
			selection := nil.
			flash := false.
			(target notNil
					and: [actionSelector notNil])
				ifTrue: [target perform: actionSelector withArguments: arguments]]
		named: 'remove selection' translated