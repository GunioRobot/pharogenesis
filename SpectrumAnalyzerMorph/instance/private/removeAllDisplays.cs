removeAllDisplays
	"Remove all currently showing displays."

	sonogramMorph ifNotNil: [sonogramMorph delete].
	graphMorph ifNotNil: [graphMorph delete].
	sonogramMorph _ graphMorph _ nil.
