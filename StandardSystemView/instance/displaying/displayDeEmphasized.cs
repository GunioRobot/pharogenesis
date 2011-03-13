displayDeEmphasized
	"Display this view with emphasis off.
	If windowBits is not nil, then simply BLT"
	bitsValid
		ifTrue:
		[self lock.
		windowBits displayAt: (self isCollapsed
			ifTrue: [self displayBox origin]
			ifFalse: [self displayBox origin - (0@labelFrame height)])]
		ifFalse:
		[super display.
		CacheBits ifTrue: [self cacheBitsAsIs]]
