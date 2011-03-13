performMenuMessage: aSelector
	"Intercept #again so the model does not get locked by keying the search text."

	| locked |
	locked _ model isLocked.
	super performMenuMessage: aSelector.
	(locked not and: [aSelector == #again and:
		[(UndoMessage sends: #undoAgain:andReselect:typedKey:) and: [UndoMessage arguments at: 3]]]) ifTrue:
			[self unlockModel]