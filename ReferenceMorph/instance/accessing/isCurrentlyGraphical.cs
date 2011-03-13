isCurrentlyGraphical
	"Answer whether the receiver is currently showing a graphical face"

	| first |
	^ submorphs size > 0 and:
		[((first _ submorphs first) isKindOf: ImageMorph) or: [first isKindOf: SketchMorph]]