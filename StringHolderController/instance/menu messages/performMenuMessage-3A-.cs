performMenuMessage: aSelector
	"Intercept #again so the model does not get locked by keying the search text."

	| hadEdits |
	hadEdits := view canDiscardEdits not.
	super performMenuMessage: aSelector.
	(hadEdits not and:
	 [aSelector == #again and:
	 [(UndoMessage sends: #undoAgain:andReselect:typedKey:) and:
	 [UndoMessage arguments at: 3]]])
		ifTrue: [self userHasNotEdited].
