neighborE
	"Answer the neightboring patch directly south of (below) this patch."

	^ self clone x: ((x + 1) \\ worldWidth)
