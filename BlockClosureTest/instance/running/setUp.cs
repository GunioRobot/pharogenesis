setUp

	closure := BlockClosureTest >> #exempleClosure createBlock: self.
	BlockClosureTest >> #exempleBlock literalAt: 2 put: closure.
	BlockClosureTest >> #exempleClosure literalAt: 1 put: closure