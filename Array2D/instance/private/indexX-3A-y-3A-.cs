indexX: x y: y
	(x < 1 or: [x > width]) ifTrue: [self errorSubscriptBounds: x].
	^ y - 1 * width + x