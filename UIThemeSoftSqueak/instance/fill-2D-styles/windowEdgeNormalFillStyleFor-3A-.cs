windowEdgeNormalFillStyleFor: anEdgeGrip
	"Return the normal window edge fillStyle for the given edge grip."
	
	|aColor|
	anEdgeGrip edgeName == #top ifTrue: [
		^Color transparent].
	aColor := anEdgeGrip paneColor.
	^(GradientFillStyle ramp: {
		0.0->aColor whiter whiter. 0.2->aColor lighter.
		0.8->aColor darker. 1.0->aColor blacker})
		origin: anEdgeGrip topLeft;
		direction: (anEdgeGrip isHorizontal
			ifTrue: [0 @ anEdgeGrip height]
			ifFalse: [anEdgeGrip width @ 0]);
		radial: false