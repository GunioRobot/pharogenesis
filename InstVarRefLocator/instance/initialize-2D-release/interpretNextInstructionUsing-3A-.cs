interpretNextInstructionUsing: aScanner 
	
	bingo _ false.
	aScanner interpretNextInstructionFor: self.
	^bingo