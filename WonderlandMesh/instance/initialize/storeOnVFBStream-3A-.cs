storeOnVFBStream: aStream
	"Read in a mesh from the vfb file"
	| bytes  write |
	"Read in the version number"
	bytes := ByteArray new: 4.
	"version"
	bytes unsignedLongAt: 1 put: 1 bigEndian: false.
	aStream nextPutAll: bytes.

	"vCount"
	bytes unsignedLongAt: 1 put: vertices size bigEndian: false.
	aStream nextPutAll: bytes.

	"Store the vertices"
	1 to: vertices size do: [:i |
		write := [:val|
			bytes unsignedLongAt: 1 put: val asIEEE32BitWord bigEndian: false.
			aStream nextPutAll: bytes.
		].
		write value: (vertices at: i) x.
		write value: (vertices at: i) y.
		write value: (vertices at: i) z.

		write value: (vtxNormals at: i) x.
		write value: (vtxNormals at: i) y.
		write value: (vtxNormals at: i) z.

		write value: (vtxTexCoords at: i) u.
		write value: (vtxTexCoords at: i) v.
	].


	"fCount"
	bytes unsignedLongAt: 1 put: faces size bigEndian: false.
	aStream nextPutAll: bytes.

	"faceDataCount"
	bytes unsignedLongAt: 1 put: 0 bigEndian: false.
	aStream nextPutAll: bytes.

	"verticesPerFace"
	bytes unsignedLongAt: 1 put: 0 bigEndian: false.
	aStream nextPutAll: bytes.

	1 to: faces size do:[:i|
		bytes unsignedLongAt: 1 put: 3 bigEndian: false.
		aStream nextPutAll: bytes.
		bytes unsignedLongAt: 1 put: (faces at: i) p1Index-1  bigEndian: false.
		aStream nextPutAll: bytes.
		bytes unsignedLongAt: 1 put: (faces at: i) p2Index-1  bigEndian: false.
		aStream nextPutAll: bytes.
		bytes unsignedLongAt: 1 put: (faces at: i) p3Index-1  bigEndian: false.
		aStream nextPutAll: bytes.
	].
