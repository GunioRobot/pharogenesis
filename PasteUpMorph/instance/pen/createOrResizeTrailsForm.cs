createOrResizeTrailsForm
	"If necessary, create a new turtleTrailsForm or resize the existing one to fill my bounds.
	On return, turtleTrailsForm exists and is the correct size.
	Use the Display depth so that color comparisons (#color:sees: and #touchesColor:) will work right."

	| newForm |
	(turtleTrailsForm isNil or: [ turtleTrailsForm extent ~= self extent ]) ifTrue:
		["resize TrailsForm if my size has changed"
		newForm _ Form extent: self extent depth: Display depth.
		turtleTrailsForm ifNotNil: [
			newForm copy: self bounds from: turtleTrailsForm
					to: 0@0 rule: Form paint ].
		turtleTrailsForm _ newForm.
		turtlePen _ nil].

	"Recreate Pen for this form"
	turtlePen ifNil: [turtlePen _ Pen newOnForm: turtleTrailsForm].