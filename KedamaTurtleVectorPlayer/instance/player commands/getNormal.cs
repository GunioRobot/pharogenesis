getNormal

	| result ret normal |
	normal _ (arrays at: 7).
	result _ KedamaFloatArray new: normal size.
	ret _ self primGetHeading: normal into: result.
	ret ifNotNil: [^ result].
