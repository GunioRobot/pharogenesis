navigateWindowBackward
	"Change the active window to the previous window."

	self previousWindow ifNotNilDo: [:m |
		m isCollapsed ifTrue: [m collapseOrExpand].
		m activate]