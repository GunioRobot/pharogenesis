roundUpStrays
	self submorphsDo:
		[:m |
			((m hasProperty: #flap) or: [m isKindOf: FlapTab])
				ifFalse:
					[m goHome.
					m isPlayfieldLike ifTrue: [m roundUpStrays]]]