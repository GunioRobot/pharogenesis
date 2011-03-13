makeGraphPaperDefault
	self makeGraphPaperGrid: 16
		background: (Color r: 0.8 g: 1.0 b: 1.0)
		line: (Color r: 0.6 g: 1.0 b: 1.0)
	"Note: if called, be sure next to call self changed: #newColor, unless it's too early
	in the initialization process"