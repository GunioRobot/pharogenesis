testDecompiler    "Smalltalk testDecompiler"
	"Decompiles the source for every method in the system, and then compiles that source and verifies that it generates (and decompiles to) identical code.  This currently fails in a number of places because some different patterns (esp involving conditionals where the first branch returns) decompile the same."
	 | methodNode oldMethod newMethod badOnes oldCodeString n |
	badOnes _ OrderedCollection new.
	Smalltalk forgetDoIts.
'Decompiling all classes...'
displayProgressAt: Sensor cursorPoint
from: 0 to: CompiledMethod instanceCount
during: [:bar | n _ 0.
	Smalltalk allBehaviorsDo:
		[:cls | 
		"Transcript cr; show: cls name."
		cls selectors do:
			[:selector | (n _ n+1) \\ 100 = 0 ifTrue: [bar value: n].
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
].
	Smalltalk browseMessageList: badOnes asSortedCollection name: 'Decompiler Discrepancies'