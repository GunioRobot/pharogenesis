isCurrentlyGraphical
	| first |
	^ submorphs size > 0 and:
		[((first _ submorphs first) isKindOf: ImageMorph) or: [first isKindOf: SketchMorph]]