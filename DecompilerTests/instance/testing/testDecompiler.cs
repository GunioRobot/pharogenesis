testDecompiler
	"self run: #testDecompiler"
	"self debug: #testDecompiler"
	| methodNode oldMethod newMethod oldCodeString |
	Smalltalk forgetDoIts.
	self systemNavigation
		allBehaviorsDo: [:cls | (self isBlockingClass: cls)
				ifFalse: [Smalltalk garbageCollect.
					cls selectors
						do: [:selector | (self isFailure: cls sel: selector)
								ifFalse: [" to help making progress
										(self
											isStoredProblems: cls theNonMetaClass
											sel: selector
											meta: cls isMeta)
										ifFalse: [ "
										Transcript cr; show: cls name.
											oldMethod := cls compiledMethodAt: selector.
											oldCodeString := (cls decompilerClass new
														decompile: selector
														in: cls
														method: oldMethod) decompileString.
											methodNode := cls compilerClass new
														compile: oldCodeString
														in: cls
														notifying: nil
														ifFail: [].
											newMethod := methodNode generate: #(0 0 0 0 ).
											self assert: oldCodeString = (cls decompilerClass new
														decompile: selector
														in: cls
														method: newMethod) decompileString
												description: cls name asString, ' ', selector asString
												resumable: true.
												
													]]]]