displayDeEmphasized 
	"Display this view with emphasis off.
	If windowBits is not nil, then simply BLT if possible,
		but force full display for top window so color is preserved."
	(bitsValid and: [controller ~~ ScheduledControllers activeController])
		ifTrue: [self lock.
				windowBits displayAt: self windowOrigin]
		ifFalse: [Display deferUpdates: true.
				super display.
				Display deferUpdates: false; forceToScreen: self windowBox.
				CacheBits ifTrue: [self cacheBitsAsIs]]
