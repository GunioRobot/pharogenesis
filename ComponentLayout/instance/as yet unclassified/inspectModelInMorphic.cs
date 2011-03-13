inspectModelInMorphic
	| insp |
	insp _ InspectorBrowser openAsMorphOn: self model.
	self world addMorph: insp; startStepping: insp