keyStroke: evt
	| view |
	(editView scrollByKeyboard: evt) ifTrue: [^self].
	self editor model: editView model.  "For evaluateSelection"
	view _ editView.  "Copy into temp for case of a self-mutating doit"
	(acceptOnCR and: [evt keyCharacter = Character cr])
		ifTrue: [^ self editor accept].
	super keyStroke: evt.
	view scrollSelectionIntoView