tabGroupCornerStyleIn: aThemedMorph
	"Allow for themes to override default behaviour."
	
	^aThemedMorph
		ifNil: [#square]
		ifNotNilDo: [:tm | tm preferredCornerStyle]