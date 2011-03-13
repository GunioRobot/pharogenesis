inspectWorldModel
	| insp |

	insp _ InspectorBrowser openAsMorphOn: myWorld model.
	myWorld addMorph: insp; startStepping: insp