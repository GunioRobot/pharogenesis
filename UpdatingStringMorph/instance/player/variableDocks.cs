variableDocks
	"Answer a list of VariableDock objects for docking up my data with an instance held in my containing playfield.  For a numeric-readout tile."

	"Is CardPlayer class holding my variableDock, or should I be using the caching mechanism in Morph>>variableDocks?"
	^ Array with: (VariableDock new 
			variableName: (getSelector allButFirst: 3) withFirstCharacterDownshifted 
			type: #number 
			definingMorph: self 
			morphGetSelector: #valueFromContents 
			morphPutSelector: #acceptValue:)