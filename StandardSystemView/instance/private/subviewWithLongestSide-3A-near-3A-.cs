subviewWithLongestSide: sideBlock near: aPoint 
	| region subs max rect side len theSub theSide |
	region _ aPoint - (4@4) corner: aPoint + (4@4).
	subs _ subViews select: [:sub | sub insetDisplayBox intersects: region].
	subs isEmpty ifTrue: [sideBlock value: #none.  ^ nil].
	max _ 0.
	subs do:
		[:sub | rect _ sub insetDisplayBox.
		side _ rect sideNearestTo: aPoint.
		len _ (side = #left) | (side = #right)
			ifTrue: [rect height]
			ifFalse: [rect width].
		len > max ifTrue: [max _ len.  theSub _ sub.  theSide _ side]].
	sideBlock value: theSide.
	^ theSub