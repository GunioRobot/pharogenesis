checkpoint
	"Return a copy of all changeable state.  See revertToCheckpoint:"

	^ {self clone. source clone. currentComment copy}