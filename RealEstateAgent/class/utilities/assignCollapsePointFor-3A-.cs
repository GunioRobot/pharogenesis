assignCollapsePointFor: aSSView
	"Offer up a location along the left edge of the screen for a collapsed SSView.
	Make sure it doesn't overlap any other collapsed frames."

	| grid otherFrames y free topLeft viewBox |
	grid _ 24.  "should be mult of 8, since manual move is gridded by 8"
	aSSView isMorph
		ifTrue: [otherFrames _ (SystemWindow windowsIn: aSSView world satisfying: [:w | true])
					collect: [:w | w collapsedFrame]
					thenSelect: [:rect | rect notNil].
				viewBox _ self reduceByFlaps: aSSView world viewBox]
		ifFalse: [otherFrames _ ScheduledControllers scheduledWindowControllers
					collect: [:aController | aController view collapsedFrame]
					thenSelect: [:rect | rect notNil].
				viewBox _ Display boundingBox].
	y _ viewBox top.
	[(y _ y + grid) <= (viewBox height - grid)]
		whileTrue:
		[topLeft _ viewBox left@y.
		free _ true.
		otherFrames do: [:w | free _ free & (topLeft ~= w topLeft)].
		free ifTrue: [^ topLeft]].
	"If all else fails..."
	^ 0 @ 0