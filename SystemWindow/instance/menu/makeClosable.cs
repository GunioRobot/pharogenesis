makeClosable
	| opaqueColor |
	mustNotClose := false.
	closeBox
		ifNil: [self addCloseBox.
			self isActive
				ifTrue: [opaqueColor := self paneColor]
				ifFalse: [opaqueColor := self paneColor muchDarker].
			self
				updateBox: closeBox
				color: (opaqueColor alphaMixed: 0.5 with: Color red).
			self extent: self extent]