setRotationCenterFromGlobalPosition: globalPt

	| oldRotation oldScale oldSetup aPlayer |
	"Neutralize all current transformations..."
	oldSetup _ self setupAngle.
	self resetForwardDirection.
	oldScale _ scalePoint.
	oldRotation _ rotationDegrees.
	scalePoint _ 1.0@1.0.
	self rotationDegrees: 0.0.

	self rotationCenter:
		(self transformFromWorld globalPointToLocal: globalPt) - bounds origin.

	"Restore all current transformations..."
	self rotationDegrees: oldRotation.
	scalePoint _ oldScale.
	self setupAngle: oldSetup.
	(aPlayer _ self topRendererOrSelf player) ifNotNil:
		[aPlayer turn: oldSetup].
	self layoutChanged.
