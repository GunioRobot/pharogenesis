someElement
	"Return some element of the Set.  "

	^ array detect: [:each | each ~~ nil] ifNone: [ nil]