doCone: node
	| radius height doSide doBottom cone |
	radius _ (node attributeValueNamed:'bottomRadius').
	height _ (node attributeValueNamed:'height').
	doSide _ (node attributeValueNamed:'side').
	doBottom _ (node attributeValueNamed:'bottom').
	cone _ B3DIndexedMesh vrml97Cone: doSide bottom: doBottom.
	self createActorFor: cone defaultName:'cone'.
	currentActor resizeRightNow: radius @ height @ radius undoable: false.
