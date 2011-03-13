exampleBackgroundSketch
	"Answer an instance suitable for serving as a prototype for a background-field incarnation of a sketch"


	| aSketch |
	aSketch _ self newSticky form: (ScriptingSystem formAtKey: #squeakyMouse).
	aSketch setProperty: #shared toValue: true.
	aSketch setProperty: #holdsSeparateDataForEachInstance toValue: true.
	^ aSketch
