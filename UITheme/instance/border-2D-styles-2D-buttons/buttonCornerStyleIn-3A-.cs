buttonCornerStyleIn: aThemedMorph
	"Allow for themes to override default behaviour."
	
	^aThemedMorph
		ifNil: [#square]
		ifNotNilDo: [:tm | 
			tm preferredButtonCornerStyle
				ifNil: [tm preferredCornerStyle]
				ifNotNilDo: [:bcs | bcs]]