roundUpStrays
	self submorphsDo:
		[:m |
			(m isFlapOrTab)
				ifFalse:
					[m goHome.
					m isPlayfieldLike ifTrue: [m roundUpStrays]]]