subviewWithLongestSide: sideBlock near: aPoint 
	| theSub theSide theLen box |
	theLen _ 0.
	subViews do:
		[:sub | box _ sub insetDisplayBox.
		box forPoint: aPoint closestSideDistLen:
			[:side :dist :len |
			(dist <= 5 and: [len > theLen]) ifTrue:
				[theSub _ sub.
				theSide _ side.
				theLen _ len]]].
	sideBlock value: theSide.
	^ theSub