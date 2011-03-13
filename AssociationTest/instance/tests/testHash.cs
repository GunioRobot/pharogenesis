testHash

	self 
		assert: (a hash = a copy hash);
		deny: (a hash = b hash)