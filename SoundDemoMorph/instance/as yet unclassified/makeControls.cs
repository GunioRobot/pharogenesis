makeControls

	| bb r cc |
	cc _ Color black.
	r _ AlignmentMorph newRow.
	r color: cc; borderWidth: 0; layoutInset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	r addMorphBack: (bb label: 'V1';			actionSelector: #playV1).
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	r addMorphBack: (bb label: 'V2';			actionSelector: #playV2).
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	r addMorphBack: (bb label: 'V3';			actionSelector: #playV3).
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	r addMorphBack: (bb label: 'All';			actionSelector: #playAll).
	bb _ SimpleButtonMorph new target: self; borderColor: cc.
	r addMorphBack: (bb label: 'Stop';		actionSelector: #stopSound).
	^ r
