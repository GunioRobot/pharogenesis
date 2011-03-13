navigateVisibleWindowForward
	"Change the active window to the next visible and
	not collapsed window."

	self nextVisibleWindow ifNotNilDo: [:m | m activate]