assignIndexedTexCoords: node in: mesh
	| attr faces vertices texCoords texIndex |
	attributes at: #currentTexCoords put: nil.
	(attr _ node attributeValueNamed: 'texCoord') notNil
		ifTrue:[attr doWith: self].
	texCoords _ attributes at: #currentTexCoords.
	texCoords == nil ifTrue:[^self].
	attr _ (node attributeValueNamed: 'texCoordIndex').
	attr size = 0 ifTrue:[attr _ (node attributeValueNamed:'coordIndex')].
	texIndex _ ReadStream on: attr.
	faces _ mesh faces.
	1 to: faces size do:[:i|
		vertices _ (faces at: i) vertices.
		[texIndex next = -1] whileTrue.
		texIndex skip: -1.
		1 to: vertices size do:[:index|
			(vertices at: index) texCoord: (texCoords at: texIndex next + 1).
		].
	].
