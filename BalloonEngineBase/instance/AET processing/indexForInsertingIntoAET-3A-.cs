indexForInsertingIntoAET: edge
	"Find insertion point for the given edge in the AET"
	| initialX index |
	self inline: false.
	initialX _ self edgeXValueOf: edge.
	index _ 0.
	[index < self aetUsedGet and:[
		(self edgeXValueOf: (aetBuffer at: index)) < initialX]]
			whileTrue:[index _ index + 1].
	[index < self aetUsedGet and:[
		(self edgeXValueOf: (aetBuffer at: index)) = initialX and:[
			(self getSorts: (aetBuffer at: index) before: edge)]]]
				whileTrue:[index _ index + 1].
	^index