newProjectViewInAWindowFor: aProject
	"Return an instance of me on a new Morphic project (in a SystemWindow)."

	| window |

	window _ (SystemWindow labelled: aProject name) model: aProject.
	window
		addMorph: (self on: aProject)
		frame: (0@0 corner: 1.0@1.0).
	^ window
