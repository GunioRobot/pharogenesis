spawnReframeHandle: event
	"The mouse has crossed a pane border.  Spawn a reframe handle."
	| resizer localPt pt ptName newBounds cursor |
	allowReframeHandles ifFalse: [^ self].
	owner ifNil: [^ self  "Spurious mouseLeave due to delete"].
	(self isActive not or: [self isCollapsed]) ifTrue:  [^ self].
	((self world ifNil: [^ self]) firstSubmorph isKindOf: NewHandleMorph) ifTrue:
		[^ self  "Prevent multiple handles"].
	pt _ event cursorPoint.
	"prevent spurios mouse leave when dropping morphs"
	owner morphsInFrontOf: self overlapping: (pt-2 extent: 4@4)
		do:[:m| m isHandMorph ifFalse:[(m fullContainsPoint: pt) ifTrue:[^self]]].
	self bounds forPoint: pt closestSideDistLen:
		[:side :dist :len |  "Check for window side adjust"
		dist <= 2  ifTrue: [ptName _ side]].
	ptName ifNil:
		["Check for pane border adjust"
		^ self spawnPaneFrameHandle: event].
	#(topLeft bottomRight bottomLeft topRight) do:
		[:corner |  "Check for window corner adjust"
		(pt dist: (self bounds perform: corner)) < 20 ifTrue: [ptName _ corner]].

	cursor _ Cursor resizeForEdge: ptName.
	resizer _ NewHandleMorph new
		sensorMode: self fastFramingOn;

		followHand: event hand
		forEachPointDo:
			[:p | localPt _ self pointFromWorld: p.
			newBounds _ self bounds
				withSideOrCorner: ptName
				setToPoint: localPt
				minExtent: self minimumExtent.
			self fastFramingOn 
			ifTrue:
				[Cursor currentCursor == cursor ifFalse:[
					event hand visible: false; refreshWorld; visible: true.
					cursor show].
				self doFastWindowReframe: ptName]
			ifFalse:
				[self bounds: newBounds.
				(Preferences roundedWindowCorners
					and: [#(bottom right bottomRight) includes: ptName])
					ifTrue:
					["Complete kluge: causes rounded corners to get painted correctly,
					in spite of not working with top-down displayWorld."
					ptName = #bottom ifFalse:
						[self invalidRect: (self bounds topRight - (6@0) extent: 7@7)].
					ptName = #right ifFalse:
						[self invalidRect: (self bounds bottomLeft - (0@6) extent: 7@7)].
					self invalidRect: (self bounds bottomRight - (6@6) extent: 7@7)]]]
		lastPointDo:
			[:p | ]
		withCursor: cursor.
	event hand world addMorphInLayer: resizer.
	resizer startStepping