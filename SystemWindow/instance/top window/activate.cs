activate
	"Bring me to the front and make me able to respond to mouse and keyboard"
	| oldTop outerMorph sketchEditor pal |
	outerMorph _ self topRendererOrSelf.
	outerMorph owner ifNil: [^ self "avoid spurious activate when drop in trash"].
	oldTop _ TopWindow.
	TopWindow _ self.
	oldTop ifNotNil: [oldTop passivate].
	outerMorph owner firstSubmorph == outerMorph
		ifFalse: ["Bring me (with any flex) to the top if not already"
				outerMorph owner addMorphFront: outerMorph].
	self submorphsDo: [:m | m unlock].
	self setStripeColorsFrom: self paneColorToUse.
	self isCollapsed ifFalse:
		[model modelWakeUpIn: self.
		self positionSubmorphs].

	(sketchEditor _ self extantSketchEditor) ifNotNil:
		[sketchEditor comeToFront.
		(pal _ self world findA: PaintBoxMorph) ifNotNil:
			[pal comeToFront]]