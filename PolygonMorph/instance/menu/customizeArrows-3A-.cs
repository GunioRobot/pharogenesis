customizeArrows: evt
	| handle origin aHand |
	aHand _ evt ifNil: [self primaryHand] ifNotNil: [evt hand].
	origin _ aHand position.
	handle _ HandleMorph new
		forEachPointDo:
			[:newPoint | handle removeAllMorphs.
			handle addMorph:
				(LineMorph from: origin to: newPoint color: Color black width: 1).
			self arrowSpec: (newPoint - origin) / 5.0]
		lastPointDo:
			[:newPoint | handle deleteBalloon.
			self halo ifNotNilDo: [:halo | halo addHandles].].
	aHand attachMorph: handle.
	handle setProperty: #helpAtCenter toValue: true.
	handle showBalloon:
'Move cursor left and right
to change arrow length and style.
Move it up and down to change width.
Click when done.' hand: evt hand.
	handle startStepping