initialExtent
	^ (Preferences inboardScrollbars and: [Smalltalk isMorphic])
		ifFalse:
       		[219 @ 309]
		ifTrue:
			[232 @ 309]