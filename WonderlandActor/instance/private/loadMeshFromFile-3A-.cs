loadMeshFromFile: meshFile
	"Load this object's mesh from the specified file"

	| dict words |

	dict _ myWonderland getSharedMeshDict.

	myMesh _ dict at: meshFile
				ifAbsent: [
							words _ (meshFile findTokens: #.).

							((words last) = 'vfb') ifTrue: [
								myMesh _ WonderlandMesh fromVFBFile: meshFile ].

							((words last) = 'obj') ifTrue: [
								myMesh _ WonderlandMesh fromOBJFile: meshFile ].

							dict at: meshFile put: myMesh.
						].
