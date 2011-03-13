insetTheScrollbars

	self allMorphsDo: [ :each | 
		(each isKindOf: PluggableTextMorph) ifTrue: [each retractable: false]
	].