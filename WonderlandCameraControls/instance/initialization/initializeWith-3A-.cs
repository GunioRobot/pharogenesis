initializeWith: aCamera
	"Initialize this instance"

	| b |

	myCamera _ aCamera.
	myScheduler _ (aCamera getWonderland) getScheduler.
	myUndoStack _ (aCamera getWonderland) getUndoStack.

	image _ camControlsBMP.

	self extent: 59@60.
	b _ (aCamera getMorph) bounds.
	self position: ((b center x) - 30) @ (b bottom).
	self openInWorld.
