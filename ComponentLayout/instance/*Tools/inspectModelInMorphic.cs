inspectModelInMorphic
	| insp |
	insp := InspectorBrowser openAsMorphOn: self model.
	self world addMorph: insp; startStepping: insp