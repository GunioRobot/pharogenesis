prototypicalToolWindow
	"Answer an example of myself seen in a tool window, for the benefit of parts-launching tools"

	| aWindow |
	aWindow := self new morphicWindow.
	aWindow setLabel: 'Selector Browser'.
	aWindow applyModelExtent.
	^ aWindow