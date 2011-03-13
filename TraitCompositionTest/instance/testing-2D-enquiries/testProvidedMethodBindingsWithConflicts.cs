testProvidedMethodBindingsWithConflicts
	| traitWithConflict methodDict |
	traitWithConflict := self createTraitNamed: #TraitWithConflict
				uses: self t1 + self t4.
	methodDict := traitWithConflict methodDict.
	self assert: methodDict size = 6.
	self 
		assert: (methodDict keys includesAllOf: #(
						#m11
						#m12
						#m13
						#m21
						#m22
						#m42
					)).
	self 
		assert: (methodDict at: #m11) decompileString = 'm11
	self traitConflict'