facesFrom: anArray for: vertices
	"Create and return a set of faces from the given index array"
	| faces vtx |
	vtx _ WriteStream on: (Array new: 4).
	faces _ WriteStream on: (Array new: anArray size // 4).
	anArray do:[:idx|
		idx = -1 ifTrue:[
			vtx position > 2 
				ifTrue:[faces nextPut: (B3DSimpleMeshFace withAll: vtx contents)].
			vtx reset.
		] ifFalse:[
			vtx nextPut: (B3DSimpleMeshVertex new position: (vertices at: idx+1)).
		].
	].
	^faces contents