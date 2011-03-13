addHandles

	| box |
	target isWorldMorph ifTrue: [^ self addHandlesForWorldHalos].
	self removeAllMorphs.  "remove old handles, if any"
	self bounds: target fullBoundsInWorld.  "update my size"
	box _ (self fullBounds expandBy: 17)
			intersect: (self world bounds insetBy: 5@5).

	(self addHandleAt: box topLeft color: Color red)
		on: #mouseDown send: #doMenu:with: to: self.
	(self addHandleAt: (box topLeft + (0@18)) color: Color lightBrown)
		on: #mouseDown send: #tearOffTile to: innerTarget.

	(self addHandleAt: (box topLeft + (18@0)) color: Color transparent)
		on: #mouseDown send: #dismiss to: self.
	(self addHandleAt: (box leftCenter) color: Color cyan)
		on: #mouseDown send: #openViewerForArgument to: innerTarget.

	(self addHandleAt: box topCenter color: Color black)
		on: #mouseDown send: #doGrab:with: to: self.

	(self addHandleAt: box topRight color: Color green)
		on: #mouseDown send: #doDup:with: to: self.

	target balloonText ifNotNil:
		[(self addHandleAt: box bottomCenter color: Color lightBlue)
			on: #mouseDown send: #mouseDownOnHelpHandle: to: innerTarget;
			on: #mouseUp send: #deleteBalloon to: innerTarget].

	(self addHandleAt: box bottomLeft color: Color blue)
		on: #mouseDown send: #startRot:with: to: self;
		on: #mouseStillDown send: #doRot:with: to: self.

	target isFlexMorph
		ifTrue: [
			(self addHandleAt: box bottomRight color: Color lightOrange)
				on: #mouseDown send: #startScale:with: to: self;
				on: #mouseStillDown send: #doScale:with: to: self]
		ifFalse: [
			(self addHandleAt: box bottomRight color: Color yellow)
				on: #mouseDown send: #startGrow:with: to: self;
				on: #mouseStillDown send: #doGrow:with: to: self].

	innerTarget addOptionalHandlesTo: self box: box.
	self addNameBeneath: box string: target "innerTarget" externalName.
	growingOrRotating _ false.
	self layoutChanged.
	self changed.
