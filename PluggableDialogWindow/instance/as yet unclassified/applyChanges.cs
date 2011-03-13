applyChanges
	"Apply the changes."

	super applyChanges.
	self applyChangesSelector ifNotNilDo: [:s |
		self model perform: s withEnoughArguments: {self}]