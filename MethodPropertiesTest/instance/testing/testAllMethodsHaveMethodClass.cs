testAllMethodsHaveMethodClass
	Smalltalk garbageCollect.
	self assert: (CompiledMethod allInstances
			reject: [:cm | cm literals last isVariableBinding
					and: [cm literals last value isBehavior
							or: [cm literals last value isTrait]]]) isEmpty
			description: 'CompiledMethods must have methodClass literal'