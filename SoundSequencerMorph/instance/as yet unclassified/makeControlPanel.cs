makeControlPanel
	| bb cc |
	cc _ Color black.
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	controlPanel _ AlignmentMorph newRow.
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	controlPanel color: bb color; borderWidth: 0; layoutInset: 0.
	controlPanel hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	controlPanel addMorphBack: (bb label: 'reset';	actionSelector: #reset).
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	controlPanel addMorphBack: (bb label: 'stop';		actionSelector: #stop).
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	controlPanel addMorphBack: (bb label: 'play';	actionSelector: #play).
