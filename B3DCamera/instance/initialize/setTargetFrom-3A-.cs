setTargetFrom: anObject
	"Make the camera point at the given object"
	| box |
	box _ anObject boundingBox.
	self target: (box origin + box corner) * 0.5.