addHandlesForWorldHalos
	"Add handles for world halos, like the man said"

	| box w |
	w _ self world ifNil:[target world].
	self removeAllMorphs.  "remove old handles, if any"
	self bounds: target bounds.
	box _ w bounds insetBy: 9.
	target addWorldHandlesTo: self box: box.

	Preferences uniqueNamesInHalos ifTrue:
		[innerTarget assureExternalName].
	self addNameBeneath: (box insetBy: (0@0 corner: 0@10)) string: innerTarget externalName.
	growingOrRotating _ false.
	self layoutChanged.
	self changed.
