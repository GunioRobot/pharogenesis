adjustPaneBorders 
	| side sub newRect outerFrame |
	outerFrame _ view displayBox.
	side _ #none.
	VBorderCursor showWhile:
		[ [sub _ view subviewWithLongestSide: [:s | side _ s]
						near: sensor cursorPoint.
		  self cursorOnBorder and: [(side = #left) | (side = #right)]]
			whileTrue: [
				self interActivityPause.
				sensor redButtonPressed ifTrue:
				[side = #left ifTrue:
					[newRect _ sub stretchFrame:
						[:f | (f withLeft: sensor cursorPoint x)
								intersect: outerFrame]
						startingWith: sub displayBox].
				side = #right ifTrue:
					[newRect _ sub stretchFrame:
						[:f | (f withRight: sensor cursorPoint x)
								intersect: outerFrame]
						startingWith: sub displayBox].
				view reframePanesAdjoining: sub along: side to: newRect]]].
	HBorderCursor showWhile:
		[ [sub _ view subviewWithLongestSide: [:s | side _ s]
						near: sensor cursorPoint.
		  self cursorOnBorder and: [(side = #top) | (side = #bottom)]]
			whileTrue: [
				self interActivityPause.
				sensor redButtonPressed ifTrue:
				[side = #top ifTrue:
					[newRect _ sub stretchFrame:
						[:f | (f withTop: sensor cursorPoint y)
								intersect: outerFrame]
						startingWith: sub displayBox].
				side = #bottom ifTrue:
					[newRect _ sub stretchFrame:
						[:f | (f withBottom: sensor cursorPoint y)
								intersect: outerFrame]
						startingWith: sub displayBox].
				view reframePanesAdjoining: sub along: side to: newRect]]]