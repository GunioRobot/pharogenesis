installNewDisplay: extent depth: depth
	"When entering a new project, install a new Display if necessary."
	| params newDisplay |
	params _ self rawParameters.
	(params notNil and:[(self parameterAt: #enable3DAcceleration) == true]) ifTrue:[
		Display isB3DDisplayScreen 
			ifTrue:[^Display setExtent: extent depth: depth].
		"Install a B3DDisplayScreen for future hardware acceleration"
		newDisplay _ (Smalltalk at: #B3DDisplayScreen ifAbsent:[^self])
					extent: extent depth: depth.
	] ifFalse:[
		"Otherwise check if the current Display is a DisplayScreen"
		Display isB3DDisplayScreen
			ifFalse:[^Display setExtent: extent depth: depth].		
		"Install a DisplayScreen for future hardware acceleration"
		newDisplay _ (Smalltalk at: #DisplayScreen ifAbsent:[^self])
					extent: extent depth: depth.
	].
	"Copy old contents of display to the (yet to be installed) newDisplay"
	newDisplay class == Display class ifTrue:[
		"A workaround for DisplayScreen <-> DisplayScreen"
		Display displayOn: newDisplay.
	] ifFalse:["*MUST* use FXBlt when switching between Displays"
		(FXBlt toForm: newDisplay) 
			sourceForm: Display; 
			combinationRule: 3; copyBits.
	].
	"And make it Display"
	Display release. "Release it while it's still Display"
	Display _ newDisplay.
	Display beDisplay.