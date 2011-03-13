closeButtonOnly
	"Replace my default control panel with one that has only a close button."

	| b r |
	self firstSubmorph delete.  "remove old control panel"
	b _ SimpleButtonMorph new target: self; borderColor: Color black.
	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; layoutInset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r wrapCentering: #topLeft.
	r addMorphBack: (b fullCopy label: 'Close'; actionSelector: #delete).
	self addMorphFront: r.
