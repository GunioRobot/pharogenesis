navigateWindowForward
	"Change the active window to the next window."

	self nextWindow ifNotNilDo: [:m |
		self currentWindow ifNotNilDo: [:w | w sendToBack].
		m isCollapsed ifTrue: [m collapseOrExpand].
		m activate]