variableDocks
	"Answer a list of VariableDock objects for docking up my data with an instance held in my containing playfield"

	^ Array with: (VariableDock new variableName: self defaultVariableName type: #text definingMorph: self morphGetSelector: #contents morphPutSelector: #setNewContentsFrom:)