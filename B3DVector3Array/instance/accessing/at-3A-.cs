at: index
	"Return the primitive vertex at the given index"
	| vtx |
	vtx _ ZeroVertex clone.
	vtx replaceFrom: 1 to: 3 with: self startingAt: index - 1 * 3 + 1.
	^vtx