cullFace
	"Return the current culling mode"
	| value |
	value _ self primRender: handle getProperty: 1.
	value = 1 ifTrue:[^#cw].
	value = -1 ifTrue:[^#ccw].
	^nil