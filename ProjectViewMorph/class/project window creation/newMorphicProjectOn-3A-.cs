newMorphicProjectOn: aPasteUpOrNil
	"Return an instance of me on a new Morphic project (in a SystemWindow)."

	| proj window |
	proj _ Project newMorphic.
	aPasteUpOrNil ifNotNil: [proj installPasteUpAsWorld: aPasteUpOrNil].
	window _ (SystemWindow labelled: proj name) model: proj.
	window
		addMorph: (self on: proj)
		frame: (0@0 corner: 1.0@1.0).
	^ window
