recompileAllFrom: firstName 
	"Recompile all classes, starting with given name."
	self deprecated: 'Use Compiler recompileAllFrom: firstName'.
	self forgetDoIts.
	self
		allClassesDo: [:class | class name >= firstName
				ifTrue: [Transcript show: class name;
						 cr.
					class compileAll]
			"Smalltalk recompileAllFrom: 'AAABodyShop'."]