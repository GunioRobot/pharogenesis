initializeB3D		"ThreeDSParser initializeB3D"
	"Initialize the 3DS Parser to use the Balloon 3D standard representations"
	| spec |
	spec _ Dictionary new.
	#(	(#camera 		#B3DCamera)
		(#material  		#B3DMaterial)
		(#meshObject 	nil"#B3DSceneObject")
		(#pointLight 	#B3DPositionalLight)
		(#spotLight 		#B3DSpotLight)
		(#splineVertex	nil "#B3DSplineVertex3DS")
		(#scene 		nil "#B3DScene")
		(#vertexArray 	#B3DVector3Array)
		(#textureArray 	#B3DTexture2Array)
	) do:[:array| spec at: array first put: array last].
	self defaultSpec: spec.
