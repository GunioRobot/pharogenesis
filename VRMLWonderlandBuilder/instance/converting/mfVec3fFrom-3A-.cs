mfVec3fFrom: anArray
	"Convert the given array into a B3DVector3Array"
	| pts |
	pts _ WriteStream on: (B3DVector3Array new: anArray size).
	anArray do:[:spec|
		pts nextPut: (B3DVector3 x: (spec at: 1) y: (spec at: 2) z: 0.0 - (spec at: 3)).
	].
	^pts contents