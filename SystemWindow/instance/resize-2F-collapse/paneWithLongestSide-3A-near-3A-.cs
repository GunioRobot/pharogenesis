paneWithLongestSide: sideBlock near: aPoint 
	| thePane theSide theLen box |
	theLen _ 0.
	paneMorphs do:
		[:pane | box _ pane bounds.
		box forPoint: aPoint closestSideDistLen:
			[:side :dist :len |
			(dist <= 5 and: [len > theLen]) ifTrue:
				[thePane _ pane.
				theSide _ side.
				theLen _ len]]].
	sideBlock value: theSide.
	^ thePane