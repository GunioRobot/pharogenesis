createAtoms: aDescriptor 
	"Returns the atom with the predefined setting"
	| atomKind requiredClass items previewX previewY |
	atomKind _ aDescriptor at: 1.
	"get the class"
	requiredClass _ self getClassOf: atomKind.
	requiredClass
		ifNotNil: ["preview position"
			previewX _ aDescriptor at: 2.
			previewY _ aDescriptor at: 3.
			"removes used settings"
			items _ ((aDescriptor copyWithout: atomKind)
						copyWithout: previewX)
						copyWithout: previewY.
			"builds the atom"
			^ ((requiredClass new
				links: (self extractLinks: items))
				forcedLinks: (self extractForcedLinks: items))
				previewPosition: previewX @ previewY].
	"Shows an error"
	self log: 'Unknown Atom kind: ' , atomKind asString.
	^ nil