doSphere: node
	| radius sphere |
	radius _ (node attributeValueNamed:'radius').
	sphere _ B3DIndexedMesh vrml97Sphere.
	self createActorFor: sphere defaultName:'sphere'.
	currentActor resizeRightNow: radius @ radius @ radius undoable: false.
