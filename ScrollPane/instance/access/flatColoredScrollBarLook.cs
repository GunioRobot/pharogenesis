flatColoredScrollBarLook
	"Currently only show the flat (not rounded) + colored-to-match-window scrollbar look when inboard."
	^ Preferences alternativeScrollbarLook and: [retractableScrollBar not or: [ScrollBar alwaysShowFlatScrollbarForAlternativeLook]]
