positionFrom: attr
	"Fix up coord systems"
	^B3DVector3 x: (attr at: 1) y: (attr at: 2) z: 0.0 - (attr at: 3).
