createClass
	^Trait
		named: name
		uses: (Compiler evaluate: self traitCompositionString)
		category: category
		
