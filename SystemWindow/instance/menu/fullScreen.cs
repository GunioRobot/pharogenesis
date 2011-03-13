fullScreen
	"Zoom Window to Full World size with possible DeskMargins"
		"SystemWindow fullScreen"
	
	| left right possibleBounds |
	left _ right _ 0.
	self paneMorphs
		do: [:pane | ((pane isKindOf: ScrollPane)
					and: [pane retractableScrollBar])
				ifTrue: [pane scrollBarOnLeft
						ifTrue: [left _ left max: pane scrollBarThickness]
						ifFalse: [right _ right max: pane scrollBarThickness]]].
	possibleBounds _ (RealEstateAgent maximumUsableAreaInWorld: self world)
				insetBy: (left @ 0 corner: right @ 0).
	((Flaps sharedFlapsAllowed
				and: [Project current flapsSuppressed not])
			or: [Preferences fullScreenLeavesDeskMargins])
		ifTrue: [possibleBounds _ possibleBounds insetBy: 22].
	self bounds: possibleBounds