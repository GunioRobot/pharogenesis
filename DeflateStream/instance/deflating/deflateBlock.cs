deflateBlock
	"Deflate the current contents of the stream"
	| flushNeeded lastIndex |
	(blockStart == nil) ifTrue:[
		"One time initialization for the first block"
		1 to: MinMatch-1 do:[:i| self updateHashAt: i].
		blockStart _ 0].

	[blockPosition < position] whileTrue:[
		(position + MaxMatch > writeLimit)
			ifTrue:[lastIndex _ writeLimit - MaxMatch]
			ifFalse:[lastIndex _ position].
		flushNeeded _ self deflateBlock: lastIndex-1
							chainLength: self hashChainLength
							goodMatch: self goodMatchLength.
		flushNeeded ifTrue:[
			self flushBlock.
			blockStart _ blockPosition].
		"Make room for more data"
		self moveContentsToFront].
