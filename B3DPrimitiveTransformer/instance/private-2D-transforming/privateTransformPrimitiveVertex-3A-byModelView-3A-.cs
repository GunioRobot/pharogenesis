privateTransformPrimitiveVertex: primitiveVertex byModelView: aMatrix
	"Use the primitive operation"
	<primitive: 'b3dTransformPrimitivePosition' module:'Squeak3D'>
	^super privateTransformPrimitiveVertex: primitiveVertex byModelView: aMatrix