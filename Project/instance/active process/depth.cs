depth
	"Return the depth of this project from the top.
	 topProject = 0, next = 1, etc."
	"Project current depth."

	| depth project |
	depth _ 0.
	project _ self.
	
	[project isTopProject]
		whileFalse:
			[project _ project parent.
			depth _ depth + 1].
	^ depth