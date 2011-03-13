fullScreenMaximumExtent
	"Zoom Window to Full World size with possible DeskMargins
	obey the maximum extent rules"
	
	| left right possibleBounds |
	left _ right _ 0.
	self paneMorphs
		do: [:pane | ((pane isKindOf: ScrollPane)
					and: [pane retractableScrollBar])
				ifTrue: [pane scrollBarOnLeft
						ifTrue: [left _ left max: pane scrollBarThickness]
						ifFalse: [right _ right max: pane scrollBarThickness]]].
	possibleBounds _ self worldBounds
				insetBy: (left @ 0 corner: right @ 0).

	self maximumExtent ifNotNil:
		[possibleBounds _ possibleBounds origin extent: ( self maximumExtent min: ( possibleBounds extent ))].
	((Flaps sharedFlapsAllowed
				and: [Project current flapsSuppressed not])
			or: [Preferences fullScreenLeavesDeskMargins])
		ifTrue: [possibleBounds _ possibleBounds insetBy: 22].
	self bounds: possibleBounds