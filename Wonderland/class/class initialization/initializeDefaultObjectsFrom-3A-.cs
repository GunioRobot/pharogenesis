initializeDefaultObjectsFrom: zipFile
	"Initialize some of the more obscure objects directly from a zip file"
	| stream mesh form mbr |
	#(
		(groundMesh		'groundMesh.vfb')
		(cameraMesh		'cameraMesh.vfb')
		(lightMesh		'lightMesh.vfb')
	) do:[:spec|
		mbr := zipFile memberNamed: spec last.
		mbr ifNotNil:[
			stream := mbr contentStream.
			stream binary.
			mesh := WonderlandMesh new createFromVFBStream: stream.
			WonderlandConstants at: spec first put: mesh.
		].
	].
	#(
		(groundTexture		'groundTexture.bmp')
		(cameraTexture		'cameraTexture.bmp')
		(lightTexture			'lightTexture.bmp')
	) do:[:spec|
		mbr := zipFile memberNamed: spec last.
		mbr ifNotNil:[
			stream := mbr contentStream.
			stream binary.
			form := Form fromBinaryStream: stream.
			WonderlandConstants at: spec first put: form asTexture.
		].
	].
	#(
		(errorSound		'errorSound.wav')
	) do:[:spec|
		mbr := zipFile memberNamed: spec last.
		mbr ifNotNil:[
			stream := mbr contentStream.
			stream binary.
			WonderlandConstants at: spec first
				put: (SampledSound fromWaveStream: stream)
		].
	].

	#(
		(camControlsBMP		'camControlsBMP.bmp')
	) do:[:spec|
		mbr := zipFile memberNamed: spec last.
		mbr ifNotNil:[
			stream := mbr contentStream.
			stream binary.
			form := Form fromBinaryStream: stream.
			WonderlandConstants at: spec first put: form.
		].
	].