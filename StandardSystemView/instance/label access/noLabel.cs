noLabel
	"A label of zero height indicates no label"
	labelFrame height > 0
		ifTrue: [labelFrame region: (labelFrame bottomLeft + (0@1) extent: labelFrame width@0).
				labelFrame borderWidth: 0.
				self uncacheBits]