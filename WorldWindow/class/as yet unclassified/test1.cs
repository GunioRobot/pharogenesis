test1
	"WorldWindow test1."

	| window world |
	world _ WiWPasteUpMorph newWorldForProject: nil.
	window _ (WorldWindow labelled: 'Inner World') model: world.
	window addMorph: world.
	world hostWindow: window.
	window openInWorld
