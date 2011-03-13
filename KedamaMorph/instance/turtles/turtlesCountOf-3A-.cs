turtlesCountOf: exampler

	| array |
	array _ exampler turtles.
	array ifNil: [^ 0].
	^ array size.
