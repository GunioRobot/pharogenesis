namedPrimitiveProlog

	| cg |
	cg _ TestCodeGenerator new.
	^Array streamContents: [:sStream |
		1 to: fullArgs size do:
			[:i |
			 sStream nextPutAll: 
				(self 
					statementsFor: 
						((parmSpecs at: i) 
							ccg: 	cg
							prolog:  [:expr | (fullArgs at: i), ' _ ', expr]
							expr: (fullArgs at: i)
							index: (fullArgs size - i))
					varName: '')]]