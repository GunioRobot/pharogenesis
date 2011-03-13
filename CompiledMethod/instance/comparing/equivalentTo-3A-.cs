equivalentTo: aCompiledMethod 
	"does not work yet with non-RB parseTrees"
	^ self = aCompiledMethod
		or: [self class == aCompiledMethod class
				and: [self numArgs == aCompiledMethod numArgs
						and: [self decompile = aCompiledMethod decompile]]].