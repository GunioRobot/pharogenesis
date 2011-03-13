displayOn: aPort
	bitsValid ifFalse: [^ self].
	windowBits displayOnPort: aPort
		at: (self isCollapsed
			ifTrue: [self displayBox origin]
			ifFalse: [self displayBox origin - (0@labelFrame height)])