at: index
	"Return the primitive vertex at the given index"
	| vtx |
	(index < 1 or:[index > self size]) ifTrue:[^self errorSubscriptBounds: index].
	vtx _ self contentsClass new.
	vtx replaceFrom: 1 to: vtx size with: self startingAt: index - 1 * self contentsSize + 1.
	^vtx