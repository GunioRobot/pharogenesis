basicPixelAtX: xPos y: yPos

	| x y i |
	x _ xPos truncated.
	y _ yPos truncated.
	((x < 0) or: [y < 0]) ifTrue: [^ 0].
	((x >= form width) or: [y >= form height]) ifTrue: [^ 0].
	i _ ((y * form width) + x) + 1.
	form bits class == ByteArray ifTrue: [form unhibernate].
	^ form bits at: i.
