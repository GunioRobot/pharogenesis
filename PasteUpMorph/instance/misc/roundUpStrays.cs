roundUpStrays
	self submorphsDo:
		[:m |
			(m wantsToBeTopmost)
				ifFalse:
					[m goHome.
					m isPlayfieldLike ifTrue: [m roundUpStrays]]]