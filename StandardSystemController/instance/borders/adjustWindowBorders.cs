adjustWindowBorders 
	| side noClickYet |
	noClickYet := true.
	VBorderCursor showWhile:
		[ [side := view displayBox sideNearestTo: sensor cursorPoint.
		  self cursorOnBorder
			and: [(side = #left) | (side = #right)
			and: [noClickYet or: [sensor redButtonPressed]]]]
			whileTrue:
			[sensor redButtonPressed ifTrue:
				[noClickYet := false.
				side = #left ifTrue:
					[view newFrame: [:f | f withLeft: sensor cursorPoint x]].
				side = #right ifTrue:
					[view newFrame: [:f | f withRight: sensor cursorPoint x]]].
			self interActivityPause]].
	HBorderCursor showWhile:
		[ [side := view displayBox sideNearestTo: sensor cursorPoint.
		  self cursorOnBorder
			and: [(side = #top) | (side = #bottom)
			and: [noClickYet or: [sensor redButtonPressed]]]]
			whileTrue:
			[sensor redButtonPressed ifTrue:
				[noClickYet := false.
				side = #top ifTrue:
					[view newFrame: [:f | f withTop: sensor cursorPoint y]].
				side = #bottom ifTrue:
					[view newFrame: [:f | f withBottom: sensor cursorPoint y]]].
		  self interActivityPause]]