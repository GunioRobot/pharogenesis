prototypicalToolWindow
	"Answer an example of myself seen in a tool window, for the benefit of parts-launching tools"

	| aWindow |
	aWindow _ self new openAsMorphEditing: nil.
	aWindow setLabel: 'Package Browser'.
	aWindow applyModelExtent.
	^ aWindow
