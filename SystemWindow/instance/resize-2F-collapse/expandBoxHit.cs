expandBoxHit
	"The full screen expand box has been hit"

	isCollapsed
		ifTrue: [self hide.
			self collapseOrExpand.
			self unexpandedFrame ifNil: [ self unexpandedFrame: fullFrame. ].
			self fullScreen.
			expandBox setBalloonText: 'contract to original size' translated.
			^ self show].
	self unexpandedFrame
		ifNil: [self unexpandedFrame: fullFrame.
			self fullScreen.
			expandBox setBalloonText: 'contract to original size' translated]
		ifNotNil: [self bounds: self unexpandedFrame.
			self unexpandedFrame: nil.
			expandBox setBalloonText: 'expand to full screen' translated]