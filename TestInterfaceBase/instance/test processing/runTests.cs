runTests

	"Cursor wait showWhile: [
		self duration: (Time millisecondsToRun: [self result: self suite run])].
	self showResult"

	| saveCursor |
	self flag: #exceptionsProblem. "Eventually switch back to Cursor wait showWhile: [...]"
	saveCursor := Cursor currentCursor.
	Cursor wait show.
	self
		duration: (Time millisecondsToRun: [self result: self suite run]);
		showResult.
	saveCursor show.