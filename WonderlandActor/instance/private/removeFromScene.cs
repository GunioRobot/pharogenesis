removeFromScene
	"Remove this actor from the scene."

	"Break ties with the current parent"
	myParent removeChild: self.

