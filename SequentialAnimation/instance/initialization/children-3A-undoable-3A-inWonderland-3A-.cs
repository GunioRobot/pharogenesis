children: childCollection undoable: canUndo inWonderland: aWonderland
	"This method initializes the Animation with all the information that it needs run."

	undoable _ canUndo.
	myWonderland _ aWonderland.
	myScheduler _ aWonderland getScheduler.
	loopCount _ 1.
	direction _ Forward.

	super initialize.

	"Add children"
	childCollection do: [:child | self append: child. child setUndoable: false ].

	"Calculate duration"
	duration _ 0.
	children do: [:child | duration _ duration + ((child getDuration) * (child getLoopCount)) ].

	state _ Waiting.
	myScheduler addAnimation: self.
