primLoadVB: dstArray startingAt: dstStart vertices: vertices normals: normals colors: colors texCoords: texCoords count: count default: defaultValues
	| hasNormals hasColors hasTexCoords pVtx defaultNormal defaultColor defaultTexCoords |
	<primitive:'b3dLoadVertexBuffer' module:'Squeak3D'>
	"self flag: #b3dDebug.	self primitiveFailed."
	defaultNormal _ defaultValues normal.
	defaultColor _ defaultValues color.
	defaultTexCoords _ defaultValues texCoords.
	hasNormals _ normals notNil.
	hasColors _ colors notNil.
	hasTexCoords _ texCoords notNil.
	1 to: count do:[:i|
		pVtx _ dstArray at: dstStart + i.
		pVtx position: (vertices at: i).
		pVtx normal: (hasNormals ifTrue:[normals at: i] ifFalse:[defaultNormal]).
		pVtx color: (hasColors ifTrue:[colors at: i] ifFalse:[defaultColor]).
		pVtx texCoords: (hasTexCoords ifTrue:[texCoords at: i] ifFalse:[defaultTexCoords]).
		dstArray at: dstStart + i put: pVtx.
	].
	^count