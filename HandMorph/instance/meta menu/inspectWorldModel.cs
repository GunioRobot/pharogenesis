inspectWorldModel
	| insp |
	insp _ InspectorBrowser openAsMorphOn: owner model.
	self world addMorph: insp; startStepping: insp