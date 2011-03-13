pickUpColorFor: aMorph
	"Show the eyedropper cursor, and modally track the mouse through a mouse-down and mouse-up cycle"

      | aHand localPt |
	aHand _ aMorph ifNil: [self activeHand] ifNotNil: [aMorph activeHand].
	aHand ifNil: [aHand _ self currentHand].
	self addToWorld: aHand world near: (aMorph ifNil: [aHand world]) fullBounds.
	self owner ifNil: [^ self].

	aHand showTemporaryCursor: (ScriptingSystem formAtKey: #Eyedropper) 
			hotSpotOffset: 6 negated @ 4 negated.    "<<<< the form was changed a bit??"

	self updateContinuously: false.
	[Sensor anyButtonPressed]
		whileFalse: 
			 [self trackColorUnderMouse].
	self deleteAllBalloons.

	(DragBox containsPoint: (localPt _ Sensor cursorPoint - self topLeft)) ifTrue:
		["Click or drag the drag-dot means to anchor as a modeless picker"
		^ self anchorAndRunModeless: aHand].
	(clickedTranslucency _ TransparentBox containsPoint: localPt)
		ifTrue: [selectedColor _ originalColor].

	self updateContinuously: true.
	[Sensor anyButtonPressed]
		whileTrue:
			 [self updateTargetColorWith: self indicateColorUnderMouse].
	aHand newMouseFocus: nil;
		showTemporaryCursor: nil;
		flushEvents.
	self delete.
		 
 