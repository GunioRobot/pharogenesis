doImageTexture: node
	| attr texFileName tex |
	"Create a new texture."
	(attr _ node attributeValueNamed: 'url') notNil
		ifTrue:[
			texFileName _ (FileDirectory on: (FileDirectory dirPathFor: scene fileURL)) fullNameFor: attr first.
			(FileDirectory default fileExists: texFileName)
				ifTrue:[tex _ myWonderland makeTextureFrom: texFileName].
			attributes at: #currentTexture put: tex].
