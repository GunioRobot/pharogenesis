addHandles
	| box worldBounds fullBox |
	worldBounds _ self world bounds.
	self removeAllMorphs.  "remove old handles, if any"
	self bounds: target bounds.  "update my size"
	fullBox _ self fullBounds expandBy: 16.
	box _ (fullBox topLeft max: (5@5)) corner: (fullBox bottomRight min: (worldBounds bottomRight - (5@5))).
	(self addHandleAt: box topLeft color: Color red)
		on: #mouseDown send: #doMenu:with: to: self.
	(self addHandleAt: box topCenter color: Color black)
		on: #mouseDown send: #doGrab:with: to: self.
	(self addHandleAt: box topRight color: Color green)
		on: #mouseDown send: #doDup:with: to: self.

	"(self addHandleAt: box leftCenter color: Color brown)
		on: #mouseDown send: #startDrag:with: to: self;
		on: #mouseStillDown send: #doDrag:with: to: self.

	(self addHandleAt: (box topCenter + ((box width // 4) @ 0)) color: Color lightYellow)
		on: #mouseDown send: #openViewer to: self."

	target balloonText ifNotNil:
		[(self addHandleAt: box bottomCenter color: Color lightBlue)
			on: #mouseDown send: #mouseDownOnHelpHandle: to: target;
			on: #mouseUp send: #deleteBalloon to: target].

	target addOptionalHandlesTo: self box: box.  "Rotation handle for SketchMorph, font controls for TextMorph, etc"

	(self addHandleAt: box bottomRight color: Color yellow)
		on: #mouseDown send: #startGrow:with: to: self;
		on: #mouseStillDown send: #doGrow:with: to: self.

	self addNameBeneath: box string: target externalName.

	growingOrRotating _ false.
	self layoutChanged.
	self changed.
