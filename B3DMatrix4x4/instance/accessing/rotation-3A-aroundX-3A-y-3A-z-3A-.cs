rotation: anAngle aroundX: xValue y: yValue z: zValue
	"set up a rotation matrix around the direction x/y/z"
	^self rotation: anAngle around:(B3DVector3 with: xValue with: yValue with: zValue)