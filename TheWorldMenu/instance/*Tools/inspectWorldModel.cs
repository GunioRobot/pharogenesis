inspectWorldModel
	| insp |

	insp := InspectorBrowser openAsMorphOn: myWorld model.
	myWorld addMorph: insp; startStepping: insp