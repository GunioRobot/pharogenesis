newInstance
	| vrmlInstance |
	vrmlClass isNil ifTrue:[self error:'No class'].
	vrmlInstance := vrmlClass fromSpec: self.
	^vrmlInstance