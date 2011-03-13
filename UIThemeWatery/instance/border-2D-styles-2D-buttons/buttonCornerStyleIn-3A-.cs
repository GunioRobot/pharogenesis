buttonCornerStyleIn: aThemedMorph
	"Allow for themes to override default behaviour."
	
	^aThemedMorph
		ifNil: [#rounded]
		ifNotNilDo: [:tm | 
			tm preferredButtonCornerStyle
				ifNil: [#rounded]
				ifNotNilDo: [:bcs | bcs]]