createFromOBJFile: filename
	"Read in a mesh from the obj file"

	| aFile pos line words oldWords triple pt1 pt2 pt3 vCount fCount index |
	
	aFile _ (CrLfFileStream readOnlyFileNamed: filename) ascii.
	line _ aFile upTo: (Character cr).
	words _ line findTokens: ' '.
	
	vCount _ 0.

	"Count the vertices"
	[ (words at: 1) = 'v' ] whileTrue: [ vCount _ vCount + 1.
									   line _ aFile upTo: (Character cr).
									   words _ line findTokens: ' ' ].

	"Now reset the file and grab the actual data"
	aFile position: 0.

	"Create the vertex array"
	vertices _ B3DVector3Array new: vCount.

	"Read in the vertices"
	line _ aFile upTo: (Character cr).
	words _ line findTokens: ' '.

	index _ 1.
	[ (words at: 1) = 'v' ] whileTrue: [ vertices at: index put:
													(B3DVector3 x: ((words at: 2) asNumber)
																y: ((words at: 3) asNumber)
																z: ((words at: 4) asNumber)).
									   index _ index + 1.
									   line _ aFile upTo: (Character cr).
									   words _ line findTokens: ' ' ].

	"Read in the texture coordinates"
	index _ 1.
	vtxTexCoords _ B3DTexture2Array new: vCount.
	[ (words at: 1) = 'vt' ] whileTrue: [ vtxTexCoords at: index
													put: (B3DVector2 u: ((words at: 2) asNumber)
																	v: ((words at: 3) asNumber)).
										index _ index + 1.
										line _ aFile upTo: (Character cr).
	  									words _ line findTokens: ' '.
									].

	"Read in the normals"
	index _ 1.
	vtxNormals _ B3DVector3Array new: vCount.
	[ (words at: 1) = 'vn' ] whileTrue: [ vtxNormals at: index
											put: (B3DVector3 x: ((words at: 2) asNumber)
															 y: ((words at: 3) asNumber)
															 z: ((words at: 4) asNumber)).
										index _ index + 1.
										line _ aFile upTo: (Character cr).
	  									words _ line findTokens: ' '.
 									].

	pos _ aFile position.
	oldWords _ words.

	"Count the faces"
	fCount _ 0.
	[ (words size) > 0 ] whileTrue: [((words at: 1) = 'f') ifTrue: [ fCount _ fCount + 1 ].
										line _ aFile upTo: (Character cr).
	  									words _ line findTokens: ' '. ].

	"Create the faces array"
	faces _ B3DIndexedTriangleArray new: fCount.

	aFile position: pos.
	words _ oldWords.

	index _ 1.
	"Read in the faces"
	[ (words size) > 0 ] whileTrue: [((words at: 1) = 'f') ifTrue: [ 
					triple _ (words at: 2) findTokens: '/'.
					pt1 _ (triple at: 1) asNumber.

					triple _ (words at: 3) findTokens: '/'.
					pt2 _ (triple at: 1) asNumber.

					triple _ (words at: 4) findTokens: '/'.
					pt3 _ (triple at: 1) asNumber.

					faces at: index put: (B3DIndexedTriangle with: pt1 with: pt2 with: pt3).
					index _ index + 1.
										].
					line _ aFile upTo: (Character cr).
	  				words _ line findTokens: ' '.
				].

	aFile close.
