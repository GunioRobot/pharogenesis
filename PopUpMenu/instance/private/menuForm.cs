menuForm
	"Answer a Form to be displayed for this menu."

	^ form ifNil: [self computeForm].
