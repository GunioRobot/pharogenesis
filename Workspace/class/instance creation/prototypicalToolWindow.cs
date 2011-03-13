prototypicalToolWindow
	"Answer an example of myself seen in a tool window, for the benefit of parts-launching tools"

	| aWorkspace |
	aWorkspace := self new embeddedInMorphicWindowLabeled: 'Workspace'.
	aWorkspace applyModelExtent.
	^ aWorkspace