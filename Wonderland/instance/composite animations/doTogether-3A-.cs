doTogether: animations
	"Create a new ParallelAnimation instance and pass it the child animations that make it up."

	| newPA |
	newPA _ ParallelAnimation new.

	newPA children: animations undoable: true inWonderland: self.

	^ newPA.
