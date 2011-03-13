basicActivate
	"Bring me to the front and make me able to respond to mouse and keyboard.
	Was #activate (sw 5/18/2001 23:20)"

	| oldTop outerMorph sketchEditor pal |
	outerMorph := self topRendererOrSelf.
	outerMorph owner ifNil: [^ self "avoid spurious activate when drop in trash"].
	oldTop := TopWindow.
	oldTop = self ifTrue: [^self].
	oldTop ifNotNil: [oldTop changed]. "invalidate with old drop shadow bounds"
	TopWindow := self.
	oldTop ifNotNil: [oldTop passivate].
	outerMorph owner firstSubmorph == outerMorph
		ifFalse: ["Bring me (with any flex) to the top if not already"
				outerMorph owner addMorphFront: outerMorph].
	self submorphsDo: [:m | m unlock].
	labelArea ifNotNil:
		[labelArea submorphsDo: [:m | m unlock].
		self setStripeColorsFrom: self paneColorToUse].
	self isCollapsed ifFalse:
		[model modelWakeUpIn: self.
		self positionSubmorphs.
		labelArea ifNil: [self adjustBorderUponActivationWhenLabeless]].

	(sketchEditor := self extantSketchEditor) ifNotNil:
		[sketchEditor comeToFront.
		(pal := self world findA: PaintBoxMorph) ifNotNil:
			[pal comeToFront]].
	self privateFullBounds: nil; changed "ensure fullBounds computed for active drop shadow"
