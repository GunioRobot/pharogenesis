spawnPaneFrameHandle: event 
	| resizer localPt side growingPane newBounds adjoiningPanes limit cursor |
	(self world firstSubmorph isKindOf: NewHandleMorph) 
		ifTrue: [^self	"Prevent multiple handles"].
	((self innerBounds withHeight: self labelHeight + 4) 
		containsPoint: event cursorPoint) 
			ifTrue: [^self	"in label or top of top pane"].
	growingPane := self paneWithLongestSide: [:s | side := s]
				near: event cursorPoint.
	growingPane ifNil: [^self].
	"don't resize pane side coincident with window side - RAA 5 jul 2000"
	(growingPane perform: side) = (self innerBounds perform: side) 
		ifTrue: [^self].
	(side == #top and: [growingPane top = self panelRect top]) ifTrue: [^self].
	adjoiningPanes := paneMorphs 
				select: [:pane | pane bounds bordersOn: growingPane bounds along: side].
	limit := adjoiningPanes isEmpty 
				ifFalse: 
					[(adjoiningPanes collect: [:pane | pane bounds perform: side]) 
						perform: ((#(#top #left) includes: side) ifTrue: [#max] ifFalse: [#min])]
				ifTrue: [self bounds perform: side].
	cursor := Cursor resizeForEdge: side.
	resizer := (NewHandleMorph new)
				sensorMode: self fastFramingOn;
				followHand: event hand
					forEachPointDo: 
						[:p | 
						localPt := self pointFromWorld: p.
						newBounds := growingPane bounds 
									withSideOrCorner: side
									setToPoint: localPt
									minExtent: 40 @ 20
									limit: limit.
						self fastFramingOn 
							ifTrue: 
								["For fast display, only higlight the rectangle during loop"

								Cursor currentCursor == cursor 
									ifFalse: 
										[(event hand)
											visible: false;
											refreshWorld;
											visible: true.
										cursor show].
								newBounds := growingPane bounds newRectButtonPressedDo: 
												[:f | 
												growingPane bounds 
													withSideOrCorner: side
													setToPoint: (self pointFromWorld: Sensor cursorPoint)
													minExtent: 40 @ 20
													limit: limit].].
								self 
									reframePanesAdjoining: growingPane
									along: side
									to: newBounds.
]
					lastPointDo: [:p | ]
					withCursor: cursor.
	event hand world addMorphInLayer: resizer.
	resizer startStepping