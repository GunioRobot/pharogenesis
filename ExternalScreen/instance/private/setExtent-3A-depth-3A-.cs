setExtent: aPoint depth: bitsPerPixel
	"Create a 3D accelerated display screen"
	| screen |
	(bits isInteger and:[depth == bitsPerPixel and: [aPoint = self extent and: 
					[self supportsDisplayDepth: bitsPerPixel]]]) ifFalse: [
		bits ifNotNil:[self primDestroyDisplaySurface: bits].
		bits _ nil.  "Free up old bitmap in case space is low"
		DisplayChangeSignature _ (DisplayChangeSignature ifNil: [0]) + 1.
		(self supportsDisplayDepth: bitsPerPixel)
			ifTrue:[depth _ bitsPerPixel]
			ifFalse:["Search for a suitable depth"
					depth _ self findAnyDisplayDepthIfNone:[nil]].
		depth == nil ifFalse:[
			bits _ self primCreateDisplaySurface: depth 
					width: aPoint x height: aPoint y].
		"Bail out if surface could not be created"
		(bits == nil) ifTrue:[
			screen _ DisplayScreen extent: aPoint depth: bitsPerPixel.
			self == Display ifTrue:[
				Display _ screen.
				Display beDisplay].
			^screen].
		width _ aPoint x.
		height _ aPoint y.
	].
	clippingBox _ super boundingBox.
	allocatedForms ifNil:[
		allocatedForms _ ExternalFormRegistry new.
		WeakArray addWeakDependent: allocatedForms].
