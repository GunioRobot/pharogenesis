makeControlPanel
	| b |
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	controlPanel _ AlignmentMorph newRow.
	controlPanel color: b color; borderWidth: 0; layoutInset: 0.
	controlPanel hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	controlPanel addMorphBack: (b fullCopy label: 'reset';	actionSelector: #reset).
	controlPanel addMorphBack: (b fullCopy label: 'stop';		actionSelector: #stop).
	controlPanel addMorphBack: (b fullCopy label: 'play';	actionSelector: #play).
