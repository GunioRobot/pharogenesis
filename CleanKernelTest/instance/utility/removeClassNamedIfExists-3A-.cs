removeClassNamedIfExists: aClassname
	Smalltalk at: aClassname ifPresent: [:cls| cls removeFromSystem].
	Smalltalk at: aClassname ifPresent: [:clss| self error: 'Error !!']