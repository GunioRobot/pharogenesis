test2
	"WorldWindow test2."

	| window world scrollPane |
	world _ WiWPasteUpMorph newWorldForProject: nil.
	window _ (WorldWindow labelled: 'Scrollable World') model: world.
	window addMorph: (scrollPane _ TwoWayScrollPane new model: world)
		frame: (0@0 extent: 1.0@1.0).
	scrollPane scroller addMorph: world.
	world hostWindow: window.
	window openInWorld
