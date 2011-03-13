fullScreen
	"SystemWindow fullScreen
	Zoom Window to Full World size with possible DeskMargins"
	| left right possibleBounds |
	left _ right _ 0.
	self paneMorphs
		do: [:pane | ((pane isKindOf: ScrollPane)
					and: [pane retractableScrollBar])
				ifTrue: [pane scrollBarOnLeft
						ifTrue: [left _ left max: pane scrollbarWidth]
						ifFalse: [right _ right max: pane scrollbarWidth]]].
	possibleBounds _ self worldBounds
				insetBy: (left @ 0 corner: right @ 0).
	((Preferences useGlobalFlaps
				and: [CurrentProjectRefactoring currentFlapsSuppressed not])
			or: [Preferences fullScreenLeavesDeskMargins])
		ifTrue: [possibleBounds _ possibleBounds insetBy: 22].
	self bounds: possibleBounds