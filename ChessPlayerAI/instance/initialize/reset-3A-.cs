reset: aBoard
	self reset.
	boardList ifNil:[
		boardList _ Array new: 100.
		1 to: boardList size do:[:i| boardList at: i put: (aBoard copy userAgent: nil)].
		boardListIndex _ 0].
	board _ aBoard.