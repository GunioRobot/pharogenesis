decompilerTestHelper
	"Decompiles the source for every method in the system, and
	then compiles that source and verifies that it generates (and
	decompiles to) identical code. This currently fails in a number
	of places because some different patterns (esp involving
	conditionals where the first branch returns) decompile the
	same. "
	"self new decompilerTestHelper"
	| methodNode oldMethod newMethod badOnes oldCodeString n |
	badOnes := OrderedCollection new.
	Smalltalk forgetDoIts.
	'Decompiling all classes...'
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: CompiledMethod instanceCount
		during: [:bar | 
			n := 0.
			self systemNavigation
				allBehaviorsDo: [:cls | 
					(self isBlockingClass: cls)
						ifFalse: [
					Smalltalk garbageCollect.
					Transcript cr; show: cls name.
					cls selectors
						do: [:selector | 
							(n := n + 1) \\ 100 = 0
								ifTrue: [bar value: n].
							(self isFailure: cls sel: selector)
								ifFalse: [oldMethod := cls compiledMethodAt: selector.
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
									oldCodeString = (cls decompilerClass new
												decompile: selector
												in: cls
												method: newMethod) decompileString
										ifFalse: [Transcript cr; show: '***' , cls name , ' ' , selector.
											badOnes add: cls name , ' ' , selector]]]]]].
	self systemNavigation browseMessageList: badOnes asSortedCollection name: 'Decompiler Discrepancies'