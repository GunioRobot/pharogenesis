prototypicalToolWindow
	"Answer an example of myself seen in a tool window, for the benefit of parts-launching tools"

	| aWindow |
	aWindow _ self new morphicWindow.
	aWindow setLabel: 'Selector Browser'.
	aWindow applyModelExtent.
	^ aWindow