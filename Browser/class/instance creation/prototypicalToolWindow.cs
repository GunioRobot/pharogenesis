prototypicalToolWindow
	"Answer an example of myself seen in a tool window, for the benefit of parts-launching tools"

	| aWindow |
	aWindow := self new openAsMorphEditing: nil.
	aWindow setLabel: 'System Browser'; applyModelExtent.
	^ aWindow