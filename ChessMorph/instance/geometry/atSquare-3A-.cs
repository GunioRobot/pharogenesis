atSquare: square
	^submorphs detect:[:any| (any valueOfProperty: #squarePosition) = square] ifNone:[nil]