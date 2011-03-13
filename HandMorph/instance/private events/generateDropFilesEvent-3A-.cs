generateDropFilesEvent: evtBuf
	"Generate the appropriate mouse event for the given raw event buffer"
	"Note: This is still in an experimental phase and will need more work"
	| position buttons modifiers stamp numFiles dragType |
	stamp _ (evtBuf at: 2).
	stamp = 0 ifTrue:[stamp _ Time millisecondClockValue].
	dragType _ evtBuf at: 3.
	position _ (evtBuf at: 4) @ (evtBuf at: 5).
	buttons _ 0.
	modifiers _ (evtBuf at: 6).
	buttons _ buttons bitOr: (modifiers bitShift: 3).
	numFiles _ (evtBuf at: 7).
	dragType = 4 ifTrue:[
		"e.g., drop"
		owner borderWidth: 0.
		^DropFilesEvent new 
			setPosition: position 
			contents: numFiles 
			hand: self.
	].
	"the others are currently not handled by morphs themselves"
	dragType = 1 ifTrue:[
		"experimental drag enter"
		owner borderWidth: 4; borderColor: owner color negated.
	].
	dragType = 2 ifTrue:[
		"experimental drag move"
	].
	dragType = 3 ifTrue:[
		"experimental drag leave"
		owner borderWidth: 0.
	].
	^nil