doItOn: stream withModule: withModuleFlag 
	"Make LargeIntegers computations with logging onto stream."
	| tester |
	withModuleFlag
		ifTrue: [self checkIfCModuleExists
				ifFalse: 
					[self inform: self name , ': Test *with* module impossible!' , Character cr asString , self moduleName , ' plugin module isn''t installed properly.'.
					^ false]]
		ifFalse: [self checkIfCModuleExists
				ifTrue: 
					[self inform: self name , ': Test *without* module impossible!' , Character cr asString , self moduleName , ' plugin module has to be renamed or removed from reachable modules path.'.
					^ false]].
	tester _ self new.
	tester stream: (stream notNil
			ifTrue: [stream]
			ifFalse: [Transcript]).
	tester stream cr; nextPutAll: self class name , ': creating test data...'.
	tester createTestData.
	tester test.
	^ true