object: anObject update: func getStartState: startFunc getEndState: endFunc style: styleFunc duration: time undoable: canUndo inWonderland: aWonderland
	"This method initializes the Animation with all the information that it needs run."

	animatedObject _ anObject.
	updateFunction _ func.
	styleFunction _ styleFunc.
	getStartStateFunction _ startFunc.
	getEndStateFunction _ endFunc.
	duration _ time.
	undoable _ canUndo.
	myScheduler _ aWonderland getScheduler.
	myWonderland _ aWonderland.
	loopCount _ 1.
	direction _ Forward.

	state _ Waiting.
	myScheduler addAnimation: self.