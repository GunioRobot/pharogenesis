addTestsFor: testName toSuite: suite 
	| cls |
	(testName indexOf: $() > 0
		ifTrue: [ Smalltalk at: #TestViaMethodCall ifPresent: [ :tvmc | tvmc addTestsFor: testName toSuite: suite] ]
		ifFalse: [cls _ testName asSymbol sunitAsClass.
			cls isAbstract
				ifTrue: [cls allSubclasses
						do: [:each | each isAbstract
								ifFalse: [each addToSuiteFromSelectors: suite]]]
				ifFalse: [cls addToSuiteFromSelectors: suite]].
	^ suite