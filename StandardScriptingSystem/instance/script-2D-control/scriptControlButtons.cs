scriptControlButtons
	"World primaryHand attachMorph: ScriptingSystem scriptControlButtons"
	| wrapper |
	wrapper _ AlignmentMorph newRow setNameTo: 'script controls'.
	wrapper vResizing: #shrinkWrap.
	wrapper addMorph: self stopButton.
	wrapper addMorphBack: self stepButton.
	wrapper addMorphBack: self goButton.
	wrapper beTransparent.
	^ wrapper