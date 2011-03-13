decompileClassesSelect: aBlock
	
	(Smalltalk classNames select: aBlock) do:
		[:cn | | cls |
		cls := Smalltalk at: cn.
		Smalltalk garbageCollect.
		 Transcript cr; show: cn.
		 cls selectors do:
			[:selector | | methodNode oldMethod newMethod oldCodeString newCodeString |
			(self isFailure: cls sel: selector) ifFalse:
				[" to help making progress
					(self
						isStoredProblems: cls theNonMetaClass
						sel: selector
						meta: cls isMeta)
					ifFalse: [ "
				Transcript nextPut: $.; flush.
				self checkDecompileMethod: (cls compiledMethodAt: selector)]]]