getHeading

	| heading result ret |
	heading _ (arrays at: 4).
	result _ KedamaFloatArray new: heading size.
	ret _ self primGetHeading: heading into: result.
	ret ifNotNil: [^ result].
	