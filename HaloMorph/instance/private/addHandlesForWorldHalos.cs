addHandlesForWorldHalos
	| box |
	self removeAllMorphs.  "remove old handles, if any"
	self bounds: target bounds.
	box _ self world bounds insetBy: 9.
	target addWorldHandlesTo: self box: box.

	self addNameBeneath: (box insetBy: (0@0 corner: 0@10)) string: innerTarget externalName.
	growingOrRotating _ false.
	self layoutChanged.
	self changed.
