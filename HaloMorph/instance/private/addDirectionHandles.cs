addDirectionHandles

	| centerHandle d w directionShaft patch patchColor crossHairColor |
	self showingDirectionHandles ifFalse: [^ self].

	directionArrowAnchor _ (target point: target referencePosition in: self world) rounded.
	patch _ target imageFormForRectangle: (Rectangle center: directionArrowAnchor extent: 3@3).
	patchColor _ patch colorAt: 1@1.

	(directionShaft _ LineMorph newSticky makeForwardArrow)
		borderWidth: 2; borderColor: (Color green orColorUnlike: patchColor).
	self positionDirectionShaft: directionShaft.
	self addMorphFront: directionShaft.
	directionShaft setCenteredBalloonText: 'Set forward direction' translated;
		on: #mouseDown send: #doDirection:with: to: self;
		on: #mouseMove send: #trackDirectionArrow:with: to: self;
		on: #mouseUp send: #setDirection:with: to: self.

	d _ 15.  "diameter"  w _ 3.  "borderWidth"
	crossHairColor _ Color red orColorUnlike: patchColor.
	(centerHandle _ EllipseMorph newBounds: (0@0 extent: d@d) color: Color transparent)
			borderWidth: w; borderColor: (Color blue orColorUnlike: patchColor);
			addMorph: (LineMorph from: (d//2)@w to: (d//2)@(d-w-1) color: crossHairColor width: 1) lock;
			addMorph: (LineMorph from: w@(d//2) to: (d-w-1)@(d//2) color: crossHairColor width: 1) lock;
			align: centerHandle bounds center with: directionArrowAnchor.
	self addMorph: centerHandle.
	centerHandle setCenteredBalloonText: 'Set rotation center' translated;
			on: #mouseDown send: #prepareToTrackCenterOfRotation:with: to: self;
			on: #mouseMove send: #trackCenterOfRotation:with: to: self;
			on: #mouseUp send: #setCenterOfRotation:with: to: self
