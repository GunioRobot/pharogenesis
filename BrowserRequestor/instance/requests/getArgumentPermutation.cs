getArgumentPermutation
	"Answer the argument permutation map.
	No support for changing argument count."
	
	^(1 to: (self getBrowser selectedMessageName ifNil: [^nil]) numArgs) asArray