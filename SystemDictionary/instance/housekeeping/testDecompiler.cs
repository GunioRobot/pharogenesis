testDecompiler    "Smalltalk testDecompiler"
	"Decompiles the source for every method in the system, and then compiles that source and verifies that it generates (and decompiles to) identical code.  This currently fails in a number of places because some different patterns (esp involving conditionals where the first branch returns) decompile the same."
	 | methodNode oldMethod newMethod badOnes oldCodeString |
	badOnes _ OrderedCollection new.
	Smalltalk forgetDoIts.
	Smalltalk allBehaviorsDo:
		[:cls |  Transcript cr; show: cls name.
		cls selectors do:
			[:selector |
			oldMethod _ cls compiledMethodAt: selector.
			oldCodeString _ (cls decompilerClass new
								decompile: selector in: cls method: oldMethod)
							decompileString.
			methodNode _ cls compilerClass new
						compile: oldCodeString
						in: cls notifying: nil ifFail: [].
			newMethod _ methodNode generate: #(0 0 0 0).
			oldCodeString = (cls decompilerClass new
								decompile: selector in: cls method: newMethod)
							decompileString ifFalse: [Transcript cr; show: '***' , cls name , ' ' , selector.
											badOnes add: cls name , ' ' , selector]]].
	^ badOnes