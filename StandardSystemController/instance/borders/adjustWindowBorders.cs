adjustWindowBorders 
	| side |
	VBorderCursor showWhile:
		[ [side _ view displayBox sideNearestTo: sensor cursorPoint.
		  self cursorOnBorder and: [(side = #left) | (side = #right)]]
			whileTrue:
			[(sensor redButtonPressed and: [self cursorOnBorder]) ifTrue:
				[side = #left ifTrue:
					[view newFrame: [:f | f withLeft: sensor cursorPoint x]].
				side = #right ifTrue:
					[view newFrame: [:f | f withRight: sensor cursorPoint x]]].
			self interActivityPause]. ].
	HBorderCursor showWhile:
		[ [side _ view displayBox sideNearestTo: sensor cursorPoint.
		  self cursorOnBorder and: [(side = #top) | (side = #bottom)]]
			whileTrue:
			[(sensor redButtonPressed and: [self cursorOnBorder]) ifTrue:
				[side = #top ifTrue:
					[view newFrame: [:f | f withTop: sensor cursorPoint y]].
				side = #bottom ifTrue:
					[view newFrame: [:f | f withBottom: sensor cursorPoint y]]].
		  self interActivityPause]]