changeMargins: evt
	| handle origin aHand oldMargin newMargin |
	aHand _ evt ifNil: [self primaryHand] ifNotNil: [evt hand].
	origin _ aHand position.
	oldMargin _ margins.
	handle _ HandleMorph new
		forEachPointDo:
			[:newPoint | handle removeAllMorphs.
			handle addMorph:
				(LineMorph from: origin to: newPoint color: Color black width: 1).
			newMargin _ (newPoint - origin max: 0@0) // 5.
			self margins: newMargin]
		lastPointDo:
			[:newPoint | handle deleteBalloon.
			self halo ifNotNilDo: [:halo | halo addHandles].
			self rememberCommand:
				(Command new cmdWording: 'margin change' translated;
					undoTarget: self selector: #margins: argument: oldMargin;
					redoTarget: self selector: #margins: argument: newMargin)].
	aHand attachMorph: handle.
	handle setProperty: #helpAtCenter toValue: true.
	handle showBalloon:
'Move cursor down and to the right
to increase margin inset.
Click when done.' hand: evt hand.
	handle startStepping