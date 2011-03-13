panelRect
	"Return the area below title bar, devoted to panes"
	^self innerBounds topLeft + (0@(self labelHeight))
					corner: self innerBounds bottomRight