getScene
	"Returns the current scene object."

	^ sceneObject ifNil:[sceneObject _ WonderlandScene newFor: self].