testBlockIsBottomContext
	self	should: [aBlockContext client ] raise: Error. "block's sender is nil, a block has no client"
	self assert: aBlockContext bottomContext = aBlockContext.
	self assert: aBlockContext secondFromBottom isNil.