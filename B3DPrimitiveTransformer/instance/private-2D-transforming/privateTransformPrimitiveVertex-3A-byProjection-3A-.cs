privateTransformPrimitiveVertex: primitiveVertex byProjection: aMatrix
	"Use the primitive operation"
	<primitive: 'b3dTransformPrimitiveRasterPosition' module:'Squeak3D'>
	^super privateTransformPrimitiveVertex: primitiveVertex byProjection: aMatrix