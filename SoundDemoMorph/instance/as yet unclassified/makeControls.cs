makeControls

	| b r |
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; layoutInset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r addMorphBack: (b fullCopy label: 'V1';			actionSelector: #playV1).
	r addMorphBack: (b fullCopy label: 'V2';			actionSelector: #playV2).
	r addMorphBack: (b fullCopy label: 'V3';			actionSelector: #playV3).
	r addMorphBack: (b fullCopy label: 'All';			actionSelector: #playAll).
	r addMorphBack: (b fullCopy label: 'Stop';		actionSelector: #stopSound).
	^ r
