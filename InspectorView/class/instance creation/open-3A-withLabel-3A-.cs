open: anInspectView withLabel: aLabel
	"Create and schedule an instance of me on the model, anInspector. "
	| topView |
	topView _ self new.
	topView addSubView: anInspectView.
	topView label: aLabel.
	topView minimumSize: 180 @ 120.
	topView controller open