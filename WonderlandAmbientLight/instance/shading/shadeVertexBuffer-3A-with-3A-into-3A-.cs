shadeVertexBuffer: vb with: aMaterial into: colorArray
	"Overridden for simplicity and speed"
	| color |
	false ifTrue:[^super shadeVertexBuffer: vb with: aMaterial into: colorArray].
	self flag: #b3dPrimitive.
	vb trackAmbientColor ifTrue:[
		1 to: vb vertexCount do:[:i|
			color _ (vb primitiveB3dColorAt: i) * lightColor ambientPart.
			colorArray add: color at: i.
		].
	] ifFalse:[
		color _ aMaterial ambientPart * lightColor ambientPart.
		colorArray += color.
	].