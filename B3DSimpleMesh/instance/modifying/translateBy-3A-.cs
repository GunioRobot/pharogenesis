translateBy: amount
	1 to: self size do:[:face | (self at: face) translateBy: amount].
	bBox ifNotNil:[bBox _ bBox translateBy: amount].