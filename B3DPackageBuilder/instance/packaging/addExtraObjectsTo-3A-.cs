addExtraObjectsTo: zip
	| stream mbr |
	#(
		(groundMesh		'groundMesh.vfb')
		(cameraMesh		'cameraMesh.vfb')
		(lightMesh		'lightMesh.vfb')
	) do:[:spec|
		stream := (ByteArray new: 1000) writeStream.
		(WonderlandConstants at: spec first) storeOnVFBStream: stream.
		zip addMember: (mbr := ZipArchiveMember newFromString: stream contents asString named: spec last).
		mbr desiredCompressionMethod: 8. "DEFLATE"
	].
	#(
		(groundTexture		'groundTexture.bmp')
		(cameraTexture		'cameraTexture.bmp')
		(lightTexture			'lightTexture.bmp')
		(camControlsBMP		'camControlsBMP.bmp')
	) do:[:spec|
		stream := (ByteArray new: 1000) writeStream.
		BMPReadWriter putForm: (WonderlandConstants at: spec first) onStream: stream.
		zip addMember: (mbr := ZipArchiveMember newFromString: stream contents asString named: spec last).
		mbr desiredCompressionMethod: 8. "DEFLATE"
	].

	#(
		(errorSound		'errorSound.wav')
	) do:[:spec|
		stream := (ByteArray new: 1000) writeStream.
		(WonderlandConstants at: spec first) storeWAVSamplesOn: stream.
		zip addMember: (mbr := ZipArchiveMember newFromString: stream contents asString named: spec last).
		mbr desiredCompressionMethod: 8. "DEFLATE"
	].
