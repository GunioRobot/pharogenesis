pixelAtX: xPos y: yPos put: value

	| x y i v |
	x _ xPos truncated.
	y _ yPos truncated.
	v _ (value asInteger max: 0) bitAnd: 16rFFFFFFFF.
	((x < 0) or: [y < 0]) ifTrue: [^ self].
	((x >= form width) or: [y >= form height]) ifTrue: [^ self].
	i _ ((y * form width) + x) + 1.
	form bits class == ByteArray ifTrue: [form unhibernate].
	form bits at: i put: v.
	self formChanged.
