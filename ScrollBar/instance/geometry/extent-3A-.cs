extent: p
	p x > p y
	ifTrue: [super extent: (p x max: 36) @ 16]
	ifFalse: [super extent: 16 @ (p y max: 36)]