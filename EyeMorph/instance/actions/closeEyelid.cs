closeEyelid
	self iris delete.
	self position: self position + (0 @ (self extent y // 2)).
	self extent: self extent x @ 2