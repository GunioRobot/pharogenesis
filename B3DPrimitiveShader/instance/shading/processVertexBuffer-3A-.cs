processVertexBuffer: vb
	"Do the primitive operation"
	(self primShadeVB: vb vertexArray 
				count: vb vertexCount 
				lights: primitiveLights 
				material: material 
				vbFlags: vb flags) ifTrue:[^self].
	"Run simulation instead"
	super processVertexBuffer: vb.