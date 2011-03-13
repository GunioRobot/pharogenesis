awaitMouseUpIn: box whileMouseDownDo: doBlock1 whileMouseDownInsideDo: doBlock2 ifSucceed: succBlock
	"The mouse has gone down in box; track the mouse, inverting the box while it's within, and if, on mouse up, the cursor was still within the box, execute succBlock.  While waiting for the mouse to come up, repeatedly execute doBlock1, and also, if the cursor is within the box, execute doBlock2.  6/10/96 sw"

	| p inside lightForm darkForm |

	p _ Sensor cursorPoint.
	inside _ box insetBy: 1.
	lightForm _ Form fromDisplay: inside.
	darkForm _ lightForm deepCopy reverse.
	[Sensor anyButtonPressed] whileTrue:
		[doBlock1 value.
		(box containsPoint: (p _ Sensor cursorPoint))
			ifTrue: [doBlock2 value..
					darkForm displayAt: inside origin]
			ifFalse: [lightForm displayAt: inside origin]].
	(box containsPoint: p)
		ifTrue: [lightForm displayAt: inside origin.
				^ succBlock value]
