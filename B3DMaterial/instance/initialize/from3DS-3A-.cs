from3DS: aDictionary
	self ambientPart: (aDictionary at: #ambient ifAbsent:[B3DColor4 r: 0.0 g: 0.0 b: 0.0 a: 1.0]).
	self diffusePart: (aDictionary at: #diffuse ifAbsent:[B3DColor4 r: 0.0 g: 0.0 b: 0.0 a: 1.0]).
	self specularPart: (aDictionary at: #specular ifAbsent:[B3DColor4 r: 0.0 g: 0.0 b: 0.0 a: 1.0]).
	(aDictionary includesKey: #textureName) 
		ifTrue:[^(aDictionary at: #textureName) -> self].