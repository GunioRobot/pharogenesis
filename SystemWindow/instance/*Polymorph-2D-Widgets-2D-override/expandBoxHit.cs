expandBoxHit
	"The full screen expand box has been hit"

	self isCollapsed
		ifTrue: [self playRestoreUpSound.
				self
					hide;
					collapseOrExpand.
				self unexpandedFrame ifNil: [self unexpandedFrame: fullFrame].
				self
					fullScreen;
					setExpandBoxBalloonText.
				^self show].
	self unexpandedFrame
		ifNil: [self playMaximizeSound.
				Preferences windowAnimation ifTrue: [self animateMaximize].
				self
					unexpandedFrame: fullFrame;
					fullScreen]
		ifNotNil: [self playRestoreDownSound.
				Preferences windowAnimation ifTrue: [self animateRestore].
				self
					bounds: self unexpandedFrame;
					unexpandedFrame: nil].
	self setExpandBoxBalloonText