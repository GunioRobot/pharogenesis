neighborN
	"Answer the neightboring patch directly north of (above) this patch."

	^ self clone y: ((y - 1) \\ worldHeight)
