includesIndex: idx
	^(self at: 1) = idx or:[(self at: 2) = idx or:[(self at: 3) = idx]]