rootForGrabOf: aMorph
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