newWorldTesting

	| world ex |

	ex _ 500@500.
	world _ PasteUpMorph newWorldForProject: nil.
	world extent: ex; color: Color orange.
	world openInWorld.
	world viewBox: (0@0 extent: ex).
	BouncingAtomsMorph new openInWorld: world.

"-----

	| world window |
	world _ PasteUpMorph newWorldForProject: nil.
	world extent: 300@300; color: Color orange.
	world viewBox: (0@0 extent: 300@300).
	window _ (SystemWindow labelled: 'the new world') model: world.
	window color: Color orange.
	window addMorph: world frame: (0@0 extent: 1.0@1.0).
	window openInWorld.

---"
