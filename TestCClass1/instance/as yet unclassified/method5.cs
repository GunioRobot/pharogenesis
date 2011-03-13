method5

	self inline: true.
	x & y.
	x | y.
	x and: [y].
	x or: [y].
	x not.

	x + y.
	x - y.
	x * y.
	x // y.
	x \\ y.
	x min: y.
	x max: y.

	x bitAnd: y.
	x bitOr: y.
	x bitXor: y.
	x bitInvert32.
	x bitShift: y.
	x >> y.
	x << y.

	x < y.
	x <= y.
	x = y.
	x >= y.
	x > y.
	x ~= y.
	x == y.
	x isNil.
	x notNil.

	[x > y] whileTrue: [ x _ x + 1 ].
	[x > y] whileFalse: [ x _ x + 1 ].

	x > y ifTrue: [ x _ x - 1 ].
	x > y ifFalse: [ x _ x + 1 ].
	x > y ifTrue: [ x _ x - 1 ] ifFalse: [ x _ x + 1 ].
	x > y ifFalse: [ x _ x + 1 ] ifTrue: [ x _ x - 1 ].

	x at: 3.
	x at: 3 put: y.

	self integerValueOf: x.
	self integerObjectOf: x.
	(self isIntegerObject: x) ifTrue: [ x _ x - 1 ].
	(self isIntegerValue: x) ifTrue: [ x _ x - 1 ].
	self cCoerce: x * (y - 1) to: 'int'.

	x _ x + 1.
	x _ x - 1.
	x preDecrement.
	y preIncrement > 0 ifTrue: [ x _ x + 1 ].
