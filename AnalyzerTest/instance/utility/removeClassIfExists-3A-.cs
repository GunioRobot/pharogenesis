removeClassIfExists: aClassname 
	Smalltalk
		at: aClassname
		ifPresent: [:cls | cls removeFromSystem] 