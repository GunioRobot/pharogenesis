createClass
	| superClass class |
	superClass := Smalltalk at: superclassName.
	class := (ClassBuilder new)
			name: name 
			inEnvironment: superClass environment 
			subclassOf: superClass
			type: type 
			instanceVariableNames: self instanceVariablesString 
			classVariableNames: self classVariablesString 
			poolDictionaries: self sharedPoolsString
			category: category.
	self traitComposition ifNotNil: [
		class setTraitComposition: (Compiler
			evaluate: self traitComposition) asTraitComposition ].
	self classTraitComposition ifNotNil: [
		class class setTraitComposition: (Compiler
			evaluate: self classTraitComposition) asTraitComposition ].
	^class.
