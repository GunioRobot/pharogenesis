copyBits
	"Override copybits to do translucency if desired"

	(combinationRule >= 30 and: [combinationRule <= 31]) 
		ifTrue: 
			[alpha isNil 
				ifTrue: [self copyBitsTranslucent: 255]
				ifFalse: [self copyBitsTranslucent: alpha]]
		ifFalse: [super copyBits]