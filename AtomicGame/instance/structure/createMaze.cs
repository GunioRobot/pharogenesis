createMaze
	| dx dy |
	currentMap buildLayout: self.
	dx _ currentMap neededSize x - bounds width.
	dx > 0
		ifTrue: [bounds _ bounds extendBy: dx @ 0].
	dy _ currentMap neededSize y.
	bounds _ bounds extendBy: 0 @ dy.
	self changed