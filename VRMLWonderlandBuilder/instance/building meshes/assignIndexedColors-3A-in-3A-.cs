assignIndexedColors: node in: mesh
	| attr colors colorIndex faces vertices |
	attributes at: #currentColors put: nil.
	(attr _ node attributeValueNamed: 'color') notNil
		ifTrue:[attr doWith: self].
	colors _ attributes at: #currentColors.
	(colors == nil or:[colors size = 0]) ifTrue:[^self].
	attr _ (node attributeValueNamed: 'colorIndex').
	attr size = 0 ifTrue:[attr _ (node attributeValueNamed:'coordIndex')].
	colorIndex _ ReadStream on: attr.
	faces _ mesh faces.
	1 to: faces size do:[:i|
		vertices _ (faces at: i) vertices.
		[colorIndex next = -1] whileTrue.
		colorIndex skip: -1.
		1 to: vertices size do:[:index|
			(vertices at: index) color: (colors at: colorIndex next + 1).
		].
	].
