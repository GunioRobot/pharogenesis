fit
	"Adjust bounds to fit the text if not in a rigid container."
	| newExtent para cBounds lastOfLines heightOfLast |
	newExtent _ (self paragraph extent max: 9@textStyle lineGrid) + (0@2).
	newExtent ~= bounds extent ifTrue:
		[(container == nil and: [successor == nil]) ifTrue:
			[para _ paragraph.  "Save para (layoutChanged smashes it)"
			super extent: newExtent.
			paragraph _ para]].
	container notNil & successor isNil ifTrue: [
		cBounds _ container bounds truncated.
		"23 sept 2000 - try to allow vertical growth"
		lastOfLines _ self paragraph lines last.
		heightOfLast _ lastOfLines bottom - lastOfLines top.
		(lastOfLines last < text size and: 
				[lastOfLines bottom + heightOfLast >= self bottom]) ifTrue: [
			container releaseCachedState.
			cBounds _ cBounds origin corner: cBounds corner + (0@heightOfLast).
		].
		self privateBounds: cBounds
	].
	self paragraph positionWhenComposed: self position.
	successor ifNotNil:
		[successor predecessorChanged].
	self changed. "Too conservative: only paragraph composition
					should cause invalidation."
