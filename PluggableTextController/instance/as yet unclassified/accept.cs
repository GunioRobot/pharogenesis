accept 
	view hasUnacceptedEdits ifFalse: [^ view flash].
	view hasEditingConflicts ifTrue:
		[(self confirm: 'Caution! This method has been changed elsewhere
since you started editing it here.  Accept anyway?') ifFalse: [^ self flash]].

	(view setText: paragraph text from: self) ifTrue:
		[initialText _ paragraph text copy.
		view ifNotNil: [view hasUnacceptedEdits: false]]    .
