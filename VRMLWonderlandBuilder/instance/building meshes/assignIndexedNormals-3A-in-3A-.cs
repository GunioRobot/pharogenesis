assignIndexedNormals: node in: mesh
	| attr normals nrmlIndex faces vertices |
	attributes at: #currentNormals put: nil.
	(attr _ node attributeValueNamed: 'normal') notNil
		ifTrue:[attr doWith: self].
	normals _ attributes at: #currentNormals.
	normals == nil ifTrue:[^self].
	attr _ (node attributeValueNamed: 'normalIndex').
	attr size = 0 ifTrue:[attr _ (node attributeValueNamed: 'coordIndex')].
	nrmlIndex _ ReadStream on: attr.
	faces _ mesh faces.
	1 to: faces size do:[:i|
		vertices _ (faces at: i) vertices.
		[nrmlIndex next = -1] whileTrue.
		nrmlIndex skip: -1.
		1 to: vertices size do:[:index|
			(vertices at: index) normal: (normals at: nrmlIndex next + 1).
		].
	].
