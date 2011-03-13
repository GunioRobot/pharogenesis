changeTabText
	| reply |
	reply _ FillInTheBlank
		request: 'new wording for this tab:'
		initialAnswer: self existingWording.
	reply isEmptyOrNil ifTrue: [^ self].
	self useStringTab: reply.
	submorphs first delete.
	self
		assumeString: reply
		font: Preferences standardFlapFont
		orientation: (Utilities orientationForEdge: edgeToAdhereTo)
		color: nil