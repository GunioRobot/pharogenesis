doCylinder: node
	| radius height doSide doBottom doTop cylinder |
	radius _ (node attributeValueNamed:'radius').
	height _ (node attributeValueNamed:'height').
	doSide _ (node attributeValueNamed:'side').
	doBottom _ (node attributeValueNamed:'bottom').
	doTop _ (node attributeValueNamed:'top').
	cylinder _ B3DIndexedMesh vrml97Cylinder: doSide bottom: doBottom top: doTop.
	self createActorFor: cylinder defaultName:'cylinder'.
	currentActor resizeRightNow: radius @ height @ radius undoable: false.
