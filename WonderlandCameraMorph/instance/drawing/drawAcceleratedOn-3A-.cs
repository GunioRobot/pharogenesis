drawAcceleratedOn: aCanvas
	| myRect |
	myRect _ (self bounds: bounds in: nil) intersect: (0@0 extent: DisplayScreen actualScreenSize).
	(myRenderer notNil and:[myRenderer isAccelerated]) ifFalse:[
		myRenderer ifNotNil:[myRenderer destroy].
		myRenderer _ nil.
	].
	myRenderer ifNotNil:[
		myRenderer _ myRenderer bufferRect: myRect.
	].
	myRenderer ifNil:[
		myRenderer _ B3DHardwareEngine newIn: myRect.
		myRenderer ifNil:[^self drawSimulatedOn: aCanvas].
	] ifNotNil:[
		myRenderer reset.
	].
	myRenderer viewportOffset: aCanvas origin.
	myRenderer clipRect: aCanvas clipRect.
	myCamera drawSceneBackground ifFalse:[
		myRenderer restoreMorphicBackground: myRect under: self.
	].
	self renderOn: myRenderer.
	outline ifNotNil:[
		self drawAcceleratedOutlineOn: myRenderer.
	].
	myRenderer restoreMorphicForeground: myRect above: self.
	Display addExtraRegion: myRect for: self.