rootForGrabOf: aMorph
	"Be sticky if sticky property is set.  Normally this would be recompiled in the unique subclass of each morph, so this is a backstop only, and for development."
	^ self isSticky
		ifTrue:
			[nil]
		ifFalse:
			[(owner = nil or: [owner isWorldOrHandMorph])
				ifTrue:
					[self]
				ifFalse:
					[owner allowSubmorphExtraction
						ifTrue: [self]
						ifFalse: [owner rootForGrabOf: aMorph]]]