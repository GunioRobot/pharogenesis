step
	"update my contents"
	| newContents |
	super step.
	""
	newContents := self contentsFromTarget.
	self visible: newContents isEmpty not.
	self contents: newContents