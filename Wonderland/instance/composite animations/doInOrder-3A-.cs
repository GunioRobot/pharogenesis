doInOrder: animations
	"Create a new SequentialAnimation instance and pass it the child animations that make it up."

	| newSA |
	newSA _ SequentialAnimation new.

	newSA children: animations undoable: true inWonderland: self.

	^ newSA.
