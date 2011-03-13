sketchEditorOrNil
	"Return a SketchEditorMorph found in the world, if any, else nil"

	
	^ Smalltalk at: #SketchEditorMorph ifPresent: [ :class | self findA: class ]
