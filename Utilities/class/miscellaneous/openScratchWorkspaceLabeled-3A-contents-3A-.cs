openScratchWorkspaceLabeled: labelString contents: initialContents
	"Open a scratch text view with the given label on the given string. A scratch text view won't warn you about unsaved changes when you close it."
	"Utilities openScratchWorkspaceLabeled: 'Scratch' contents: 'Hello. world!'"

	| model topView stringView |
	model _ StringHolder new contents: initialContents.
	topView _ StandardSystemView new.
	topView
		model: model;
		label: labelString;
		minimumSize: 180@120.
	topView borderWidth: 1.
	stringView _ PluggableTextView on: model 
		text: #contents
		accept: nil
		readSelection: #contentsSelection
		menu: #codePaneMenu:shifted:.
	stringView
		askBeforeDiscardingEdits: false;
		window: (0@0 extent: 180@120).
	topView addSubView: stringView.
	topView controller open.
