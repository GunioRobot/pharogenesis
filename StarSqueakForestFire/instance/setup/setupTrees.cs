setupTrees
	"Setup a forest with treePercentage of trees."

	self patchesDo: [:p |
		p set: #isUnburnt to: 0.
		p set: #flameLevel to: 0.
		(10 * treePercentage) > (self random: 1000) ifTrue: [
			p set: #isUnburnt to: 1.
			p color: Color green]].
