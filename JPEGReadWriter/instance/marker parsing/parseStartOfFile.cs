parseStartOfFile

	| length markerStart value n |
	markerStart _ self position.
	length _ self nextWord.
	dataPrecision _ self next.
	dataPrecision = 8
		ifFalse: [self error: 'cannot handle ', dataPrecision printString, '-bit components'].
	height _ self nextWord.
	width _ self nextWord.
	n _ self next.
	(height = 0) | (width = 0) | (n = 0) ifTrue: [self error: 'empty image'].
	(length - (self position - markerStart)) ~= (n * 3)
		ifTrue: [self error: 'component length is incorrect'].
	components _ Array new: n.
	1 to: components size do:
		[:i |
		components
			at: i
			put:
				(JPEGColorComponent new
					id: self next;
					"heightInBlocks: (((value _ self next) >> 4) bitAnd: 16r0F);
					widthInBlocks: (value bitAnd: 16r0F);"
					widthInBlocks: (((value _ self next) >> 4) bitAnd: 16r0F);
					heightInBlocks: (value bitAnd: 16r0F);

					qTableIndex: self next + 1)]