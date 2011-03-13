createOrResizeTrailsForm
	"If necessary, create a new turtleTrailsForm or resize the existing one to fill my bounds. On return, turtleTrailsForm exists and is the correct size."

	| newForm |
	turtleTrailsForm ifNil: [
		"create new turtleTrailsForm if needed"
		turtleTrailsForm _ Form extent: self extent depth: 8.
		turtlePen _ nil.
		^ self].

	turtleTrailsForm extent = self extent ifFalse: [
		"resize turtleTrailsForm if my size has changed"
		newForm _ Form extent: self extent depth: 8.
		newForm
			copy: self bounds
			from: turtleTrailsForm
			to: 0@0
			rule: Form paint.
		turtleTrailsForm _ newForm.
		turtlePen _ nil].
