bounds
	textSegments ifNil: [^ nil].
	^ textSegments inject: (textSegments first at: 1)
		into: [:bnd :each | bnd merge: (each at: 1)]