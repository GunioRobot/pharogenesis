paragraph: para bounds: bounds color: c 
	self comment:'paragraph with bounds: ' with:bounds.
	self gsave.
	para
		displayOn: self
		using: (PostscriptCharacterScanner scannerWithCanvas:self paragraph:para bounds:bounds)
		at: bounds topLeft.
	self grestore.
