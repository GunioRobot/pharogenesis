getFullBoundsFor: aCamera
	"Return the 2D bounds of the receiver and its children or nil if not visible"
	| box bounds |
	box _ self getBoundsFor: aCamera.
	myChildren do:[:child|
		bounds _ child getFullBoundsFor: aCamera.
		bounds == nil ifFalse:[
			box == nil ifTrue:[box _ bounds] ifFalse:[box _ box quickMerge: bounds].
		].
	].
	^box