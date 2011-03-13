addHandlesForWorldHalos

	| box |
	self removeAllMorphs.  "remove old handles, if any"
	self bounds: target bounds.
	box _ self world bounds insetBy: 9.

	(self addHandleAt: box topLeft color: Color red)
		on: #mouseDown send: #doMenu:with: to: self.
	(self addHandleAt: (box topLeft + (0@20)) color: Color lightBrown)
		on: #mouseDown send: #tearOffTile to: target.
	(self addHandleAt: box leftCenter color: Color cyan)
		on: #mouseDown send: #openViewerForArgument to: target.

	target balloonText ifNotNil:
		[(self addHandleAt: box bottomCenter color: Color lightBlue)
			on: #mouseDown send: #mouseDownOnHelpHandle: to: target;
			on: #mouseUp send: #deleteBalloon to: target].

	innerTarget addOptionalHandlesTo: self box: box.
	self addNameBeneath: (box insetBy: (0@0 corner: 0@10)) string: innerTarget externalName.
	growingOrRotating _ false.
	self layoutChanged.
	self changed.
