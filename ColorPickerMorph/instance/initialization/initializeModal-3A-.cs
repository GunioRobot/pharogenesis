initializeModal: beModal
	"Initialize the receiver.  If beModal is true, it will be a modal color picker, else not"

	isModal _ beModal.
	self removeAllMorphs.
	isModal ifFalse:
		[theSelectorDisplayMorph _ AlignmentMorph newRow
			color: Color white;
			borderWidth: 1;
			borderColor: Color red;
			hResizing: #shrinkWrap;
			vResizing: #shrinkWrap;
			addMorph: (StringMorph contents: 'theSelector').
		self addMorph: theSelectorDisplayMorph.

		self addMorph: (SimpleButtonMorph new borderWidth: 0;
			label: 'x' font: nil; color: Color transparent;
			actionSelector: #delete; target: self; useSquareCorners;
			position: self topLeft - (0@3); extent: 10@12;
			setCenteredBalloonText: 'dismiss color picker')].

	self addMorph: ((Morph newBounds: (DragBox translateBy: self topLeft))
			color: Color transparent; setCenteredBalloonText: 'put me somewhere').
	self addMorph: ((Morph newBounds: (RevertBox translateBy: self topLeft))
			color: Color transparent; setCenteredBalloonText: 'restore original color').
	self addMorph: ((Morph newBounds: (FeedbackBox translateBy: self topLeft))
			color: Color transparent; setCenteredBalloonText: 'shows selected color').
	self addMorph: ((Morph newBounds: (TransparentBox translateBy: self topLeft))
			color: Color transparent; setCenteredBalloonText: 'adjust translucency').

	self buildChartForm.
	
	selectedColor ifNil: [selectedColor _ Color white].
	sourceHand _ nil.
	deleteOnMouseUp _ false.
	updateContinuously _ true.
