newMVCProject
	"Create an instance of me on a new MVC project (in a SystemWindow)."

	| proj window |
	proj _ Project new.
	window _ (SystemWindow labelled: proj name) model: proj.
	window
		addMorph: (self on: proj)
		frame: (0@0 corner: 1.0@1.0).
	proj projectParameters at: #globalFlapsEnabledInProject put: false.
	^ window
