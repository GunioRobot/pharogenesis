< aString 

	^ (self multiStringCompare: self with: aString asMultiString collated: nil) = 1.
