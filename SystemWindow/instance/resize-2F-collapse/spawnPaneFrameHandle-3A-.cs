spawnPaneFrameHandle: event
	| resizer localPt side growingPane newBounds adjoiningPanes limit |
	(self world firstSubmorph isKindOf: NewHandleMorph) ifTrue:
		[ ^ self  "Prevent multiple handles"].
	((self innerBounds withHeight: self labelHeight+4) containsPoint: event cursorPoint)
		ifTrue: [^ self "in label or top of top pane"].
	growingPane _ self paneWithLongestSide: [:s | side _ s] near: event cursorPoint.
	growingPane ifNil: [^ self].

	adjoiningPanes _ paneMorphs select: [:pane | pane bounds bordersOn: growingPane bounds along: side].
	limit _ adjoiningPanes isEmpty
		ifFalse: [ (adjoiningPanes collect: [:pane | pane bounds perform: side])
			perform: ((#(top left) includes: side) ifTrue: [#max] ifFalse: [#min])]
		ifTrue: [self bounds perform: side].

	resizer _ NewHandleMorph new
		followHand: event hand
		forEachPointDo:
			[:p | localPt _ self pointFromWorld: p.
			newBounds _ growingPane bounds withSideOrCorner: side setToPoint: localPt minExtent: 40@20 limit: limit.
			self fastFramingOn 
			ifTrue:
				["For fast display, only higlight the rectangle during loop"
				newBounds _ growingPane bounds
					 newRectFrom:
					[:f | growingPane bounds withSideOrCorner: side
							setToPoint: (self pointFromWorld: Sensor cursorPoint)
							minExtent: 40@20 limit: limit].
					self reframePanesAdjoining: growingPane along: side
						to: newBounds]
			ifFalse:
				[self reframePanesAdjoining: growingPane along: side to: newBounds]]
		lastPointDo: [:p | ].
	event hand world addMorph: resizer.
	resizer startStepping