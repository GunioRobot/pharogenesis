potentialController
	"Answer the controller of the window directly under the cursor.  Answer nil if the cursor is not over a window or the window is collapsed."

	| pt |
	pt _ Sensor cursorPoint.
	^scheduledControllers detect: [:controller |
		(controller view insetDisplayBox containsPoint: pt)
		& (controller isKindOf: StandardSystemController)
		and: [controller view isCollapsed not]] ifNone: [screenController]