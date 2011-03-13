maybeRelabel: newLabel
	"If the change set name given by newLabel is already in use, do nothing; else relabel the view"

	(newLabel isEmpty or: [newLabel = self label])
		ifTrue: [^ self].
	(ChangeSet named: newLabel) == nil
		ifFalse: [^ self].
	self relabel: newLabel