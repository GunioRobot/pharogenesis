indexFromPoint: pt
	"Which of 256 colors is the one under the mouse?? pt is relative to bounds topLeft."

	| this |
	this _ pt y // cellSize y * 16 + (pt x // cellSize x + 1).
	^ (this min: 256) max: 1.
