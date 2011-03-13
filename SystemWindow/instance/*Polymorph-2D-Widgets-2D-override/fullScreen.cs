fullScreen
	"Zoom Window to Full World size with possible DeskMargins"
		"SystemWindow fullScreen"
	
	| left right possibleBounds |
	left := right := 0.
	self paneMorphs
		do: [:pane | ((pane isKindOf: ScrollPane)
					and: [pane retractableScrollBar])
				ifTrue: [pane scrollBarOnLeft
						ifTrue: [left := left max: pane scrollBarThickness]
						ifFalse: [right := right max: pane scrollBarThickness]]].
	possibleBounds := (RealEstateAgent maximumUsableAreaInWorld: self world)
				insetBy: (left @ 0 corner: right @ 0).
	self class environment at: #Flaps ifPresent: [:cl |
		((cl sharedFlapsAllowed
				and: [Project current flapsSuppressed not])
			or: [Preferences fullScreenLeavesDeskMargins])
		ifTrue: [possibleBounds := possibleBounds insetBy: 22]].
	self bounds: possibleBounds