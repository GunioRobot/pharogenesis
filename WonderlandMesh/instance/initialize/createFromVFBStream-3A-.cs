createFromVFBStream: aFile
	"Read in a mesh from the vfb file"

	| w x y z bytes version vCount fCount verticesPerFace  |
	
	"Read in the version number"
	bytes _ aFile next: 4.
	version _ bytes unsignedLongAt: 1 bigEndian: false.

	(version = 1) ifTrue: [
							"Read in the number of vertices"
							bytes _ aFile next: 4.
							vCount _ bytes unsignedLongAt: 1 bigEndian: false.
						]
				ifFalse: [
							vCount _ version.
							version _ 0.
						].

	(vCount > 0) ifTrue: [
		vertices _ B3DVector3Array new: vCount.
		vtxNormals _ B3DVector3Array new: vCount.
		vtxTexCoords _ B3DTexture2Array new: vCount.

		"Read in the vertices"
		1 to: vCount do: [:i | bytes _ aFile next: 32.
						x _ Float fromIEEE32Bit: (bytes unsignedLongAt: 1 bigEndian: false).
						y _ Float fromIEEE32Bit: (bytes unsignedLongAt: 5 bigEndian: false).
						z _ Float fromIEEE32Bit: (bytes unsignedLongAt: 9 bigEndian: false).
						vertices at: i put: (B3DVector3 x: (x negated) y: y z: z).

						x _ Float fromIEEE32Bit: (bytes unsignedLongAt: 13 bigEndian: false).
						y _ Float fromIEEE32Bit: (bytes unsignedLongAt: 17 bigEndian: false).
						z _ Float fromIEEE32Bit: (bytes unsignedLongAt: 21 bigEndian: false).
						vtxNormals at: i put: (B3DVector3 x: (x negated) y: y z: z).

						x _ Float fromIEEE32Bit: (bytes unsignedLongAt: 25 bigEndian: false).
						y _ Float fromIEEE32Bit: (bytes unsignedLongAt: 29 bigEndian: false).
						vtxTexCoords at: i put: (B3DVector2 u: x v: y).

						].

		"Read in the number of faces"
		bytes _ aFile next: 4.
		fCount _ bytes unsignedLongAt: 1 bigEndian: false.

		(fCount > 0) ifTrue: [
				"Read past the faceDataCount value"
				aFile next: 4.

				(version = 0) ifTrue: [ verticesPerFace _ 0. ]
							ifFalse: [
										bytes _ aFile next: 4.
										verticesPerFace _ bytes unsignedLongAt: 1 bigEndian: false.
									].

				(verticesPerFace = 0) ifTrue: [
							faces _ B3DIndexedTriangleArray new: fCount.

							1 to: fCount do: [: i |
								bytes _ aFile next: 4.
								w _ bytes unsignedLongAt: 1 bigEndian: false.

								(w = 3) ifTrue: [
									bytes _ aFile next: 4.
									x _ (bytes unsignedLongAt: 1 bigEndian: false) + 1.

									bytes _ aFile next: 4.
									y _ (bytes unsignedLongAt: 1 bigEndian: false) + 1.

									bytes _ aFile next: 4.
									z _ (bytes unsignedLongAt: 1 bigEndian: false) + 1.

									faces at: i put: (B3DIndexedTriangle with: x with: y with: z).
 												]
										ifFalse: [ 1 to: w do: [: j | aFile next: 4] ].

											].
																		].

							].  " (end if fCount > 0) "
						]	" (end if vCount > 0) "
			ifFalse: [ ^ nil ].