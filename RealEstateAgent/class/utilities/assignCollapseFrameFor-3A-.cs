assignCollapseFrameFor: aSSView 
	"Offer up a location along the left edge of the screen for a collapsed SSView. Make sure it doesn't overlap any other collapsed frames."

	| grid otherFrames topLeft viewBox collapsedFrame extent newFrame verticalBorderDistance top |
	grid _ 8.
	verticalBorderDistance _ 8.
	aSSView isMorph
		ifTrue: [otherFrames _ (SystemWindow windowsIn: aSSView world satisfying: [:w | w ~= aSSView])
						collect: [:w | w collapsedFrame]
						thenSelect: [:rect | rect notNil].
				viewBox _ self reduceByFlaps: aSSView world viewBox]
		ifFalse: [otherFrames _ ScheduledControllers scheduledWindowControllers
						collect: [:aController | aController view ~= aSSView ifTrue: [aController view collapsedFrame]]
						thenSelect: [:rect | rect notNil].
				viewBox _ Display boundingBox].
	collapsedFrame _ aSSView collapsedFrame.
	extent _ collapsedFrame notNil
				ifTrue: [collapsedFrame extent]
				ifFalse: [aSSView isMorph
					ifTrue: [aSSView getRawLabel width + aSSView labelWidgetAllowance @ (aSSView labelHeight + 2)]
					ifFalse: [(aSSView labelText extent x + 70) @ aSSView labelHeight
							min: aSSView labelDisplayBox extent]].
	collapsedFrame notNil
		ifTrue: [(otherFrames anySatisfy: [:f | collapsedFrame intersects: f])
				ifFalse: ["non overlapping"
					^ collapsedFrame]].
	top _ viewBox top + verticalBorderDistance.
	[topLeft _ viewBox left @ top.
	newFrame _ topLeft extent: extent.
	newFrame bottom <= (viewBox height - verticalBorderDistance)]
		whileTrue: 
			[(otherFrames anySatisfy: [:w | newFrame intersects: w])
				ifFalse: ["no overlap"
					^ newFrame].
			top _ top + grid].
	"If all else fails... (really to many wins here)"
	^ 0 @ 0 extent: extent