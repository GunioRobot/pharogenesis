displayDeEmphasized 
	"Display this view with emphasis off.
	If windowBits is not nil, then simply BLT if possible,
		but force full display for top window so color is preserved."
	(bitsValid and: [controller ~~ ScheduledControllers activeController])
		ifTrue: [self lock.
				windowBits displayAt: self windowOrigin]
		ifFalse: [super display.
				CacheBits ifTrue: [self cacheBitsAsIs]]
