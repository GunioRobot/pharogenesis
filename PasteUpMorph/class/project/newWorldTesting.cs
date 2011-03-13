newWorldTesting

	| world ex |

	ex := 500@500.
	world := PasteUpMorph newWorldForProject: nil.
	world extent: ex; color: Color orange.
	world openInWorld.
	world viewBox: (0@0 extent: ex).
	Smalltalk at: #BouncingAtomsMorph
		ifPresent: [ :cl | cl new openInWorld: world].

