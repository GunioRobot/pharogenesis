openViewerForTarget: evt with: aHandle
	"Open  a viewer for my inner target"

	self obtainHaloForEvent: evt andRemoveAllHandlesBut: nil.
	innerTarget openViewerForArgument