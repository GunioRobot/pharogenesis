doBox: node
	| size box |
	size _ (node attributeValueNamed:'size').
	box _ B3DIndexedMesh vrml97Box.
	self createActorFor: box defaultName:'box'.
	currentActor resizeRightNow: size first @ size second @ size third undoable: false.
