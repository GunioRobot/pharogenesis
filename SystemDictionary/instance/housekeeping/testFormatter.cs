testFormatter    "Smalltalk testFormatter"
	"Reformats the source for every method in the system, and then
	compiles that source and verifies that it generates identical code"
	 | newCodeString methodNode oldMethod newMethod badOnes |
	badOnes _ OrderedCollection new.
	Smalltalk forgetDoIts.
	Smalltalk allBehaviorsDo:
		[:cls |  Transcript cr; show: cls name.
		cls selectors do:
			[:selector |
			newCodeString _ (cls compilerClass new)
				format: (cls sourceCodeAt: selector)
				in: cls notifying: nil.
			methodNode _ cls compilerClass new
						compile: newCodeString
						in: cls notifying: nil ifFail: [].
			newMethod _ methodNode generate: #(0 0 0 0).
			oldMethod _ cls compiledMethodAt: selector.
			oldMethod = newMethod ifFalse: [Transcript cr; show: '***' , cls name , ' ' , selector.
											badOnes add: cls name , ' ' , selector]]].
	^ badOnes