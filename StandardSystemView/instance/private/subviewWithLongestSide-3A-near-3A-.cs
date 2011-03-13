subviewWithLongestSide: sideBlock near: aPoint 
	| theSub theSide theLen box |
	theLen := 0.
	subViews do:
		[:sub | box := sub insetDisplayBox.
		box forPoint: aPoint closestSideDistLen:
			[:side :dist :len |
			(dist <= 5 and: [len > theLen]) ifTrue:
				[theSub := sub.
				theSide := side.
				theLen := len]]].
	sideBlock value: theSide.
	^ theSub