neighborS
	"Answer the neightboring patch directly south of (below) this patch."

	^ self clone y: ((y + 1) \\ worldHeight)
