fit
	"Adjust bounds to fit the text if not in a rigid container."
	| newExtent para |
	newExtent _ (self paragraph extent max: 9@textStyle lineGrid) + (0@2).
	newExtent ~= bounds extent ifTrue:
		[(container == nil and: [successor == nil]) ifTrue:
			[para _ paragraph.  "Save para (layoutChanged smashes it)"
			super extent: newExtent.
			paragraph _ para]].
	container ifNotNil:
		[self privateBounds: container bounds truncated].
	self paragraph positionWhenComposed: self position.
	successor ifNotNil:
		[successor predecessorChanged].
	self changed. "Too conservative: only paragraph composition
					should cause invalidation."
