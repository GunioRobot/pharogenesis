mfVec2fFrom: anArray
	"Convert the given array into a B3DVector2Array"
	| pts |
	pts _ WriteStream on: (B3DTexture2Array new: anArray size).
	anArray do:[:spec|
		pts nextPut: (B3DVector2 u: (spec at: 1) v: (spec at: 2)).
	].
	^pts contents