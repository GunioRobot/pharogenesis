defaultSpec
	"The default spec is a dictionary with
		#camera -> CameraClassName (e.g., #B3DCamera3DS)
		#material -> MaterialClassName (e.g., #B3DMaterial3DS)
		#meshObject -> MeshObjectClassName (e.g., #B3DObject3DS)
		#pointLight -> PointLightClassName (e.g., #B3DPositionalLight)
		#spotLight -> SpotLightClassName (e.g., #B3DSpotLight)
		#scene -> SceneClassName (e.g., #B3DScene3DS)
		#splineVertex -> SplineVertexClass (e.g., B3DSplineVertex3DS)
	all responding to #from3DS: aDictionary and
		#vertexArray -> VertexArrayClassName (e.g., #B3DVector3Array)
		#textureArray -> TextureArrayClassName (e.g., #B3DTexture2Array)
	for constructing large arrays of vertex / texture coordinates
	(responding to the standard array messages #new: #at: and #at:put:)
	"
	"ThreeDSParser defaultSpec"
	^DefaultSpec