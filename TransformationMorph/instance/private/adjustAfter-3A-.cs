adjustAfter: changeBlock
	"Cause this morph to remain cetered where it was before, and
	choose appropriate smoothing, after a change of scale or rotation."
	| oldCenter |
	oldCenter _ self center.
	changeBlock value.
	(self scale < 1.0 or: [self angle ~= (self angle roundTo: Float pi / 2.0)])
		ifTrue: [smoothing _ 2]
		ifFalse: [smoothing _ 1].
	self layoutChanged.
	self position: oldCenter - (self extent // 2)