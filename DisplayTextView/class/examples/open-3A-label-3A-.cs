open: textOrString label: aLabel
	"Create a system view with a paragraph editor in it.  6/2/96 sw"

	| topView aDisplayTextView |
	aDisplayTextView _ DisplayTextView new model: textOrString asDisplayText.
	aDisplayTextView borderWidth: 2.
	topView _ StandardSystemView new.
	topView label: aLabel.
	topView addSubView: aDisplayTextView.
	topView controller open

	"DisplayTextView open: 'Great green gobs' label: 'Gopher Guts'"