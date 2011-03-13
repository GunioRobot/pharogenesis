assignCollapsePointFor: aSSView
	"Offer up a location along the left edge of the screen for a collapsed SSView.
	Make sure it doesn't overlap any other collapsed frames."
	| grid otherFrames y free topLeft |
	grid _ 24.  "should be mult of 8, since manual move is gridded by 8"
	otherFrames _ Smalltalk isMorphic
		ifTrue: [(SystemWindow windowsIn: World satisfying: [:w | true])
					collect: [:w | w collapsedFrame]
					thenSelect: [:rect | rect notNil]]
		ifFalse: [ScheduledControllers scheduledWindowControllers
					collect: [:aController | aController view collapsedFrame]
					thenSelect: [:rect | rect notNil]].
	y _ 0.
	[(y _ y + grid) <= (Display height - grid)]
		whileTrue:
		[topLeft _ 0@y.
		free _ true.
		otherFrames do: [:w | free _ free & (topLeft ~= w topLeft)].
		free ifTrue: [^ topLeft]].
	"If all else fails..."
	^ 0 @ 0