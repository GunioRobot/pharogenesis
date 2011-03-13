exampleBackgroundSketch
	"Answer an instance suitable for serving as a prototype for a background-field incarnation of a sketch"


	| aSketch |
	aSketch := self newSticky form: (ScriptingSystem formAtKey: #squeakyMouse).
	aSketch setProperty: #shared toValue: true.
	aSketch setProperty: #holdsSeparateDataForEachInstance toValue: true.
	^ aSketch
