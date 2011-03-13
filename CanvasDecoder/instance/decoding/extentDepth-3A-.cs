extentDepth: command
	| depth extent |
	extent := self class decodePoint: (command at: 2).
	depth := self class decodeInteger: (command at: 3).

	drawingCanvas := FormCanvas  extent: extent depth: depth.