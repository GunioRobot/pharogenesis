parentsDo: aBlock
	"Run a block for all my parents starting from the top."

	parent ifNotNil: [
		parent parentsDo: aBlock.
		aBlock value: parent]