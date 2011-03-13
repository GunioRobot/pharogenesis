drawOn: aCanvas

	| f cache |
	f _ self class fridgeForm ifNil: [^super drawOn: aCanvas].
	cache _ Form extent: bounds extent depth: aCanvas depth.
	f
		displayInterpolatedIn: cache boundingBox truncated
		on: cache.
	cache replaceColor: Color black withColor: Color transparent.
	aCanvas 
		translucentImage: cache
		at: bounds origin.
