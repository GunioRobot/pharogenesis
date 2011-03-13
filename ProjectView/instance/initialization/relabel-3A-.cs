relabel: newLabel
	(newLabel isEmpty or: [newLabel = self label])
		ifTrue: [^ self].
	(ChangeSorter changeSetNamed: newLabel) == nil
		ifFalse: [self inform: 'Sorry that name is already used'.
				^ self].
	model projectChangeSet name: newLabel.
	super relabel: newLabel