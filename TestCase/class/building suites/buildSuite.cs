buildSuite
	| suite |
	suite _ TestSuite new.
	^ self isAbstract
		ifTrue: [
			suite name: self name asString.
			self allSubclasses
				do: [:each | each isAbstract
						ifFalse: [each addToSuiteFromSelectors: suite]].
			suite]
		ifFalse: [self addToSuiteFromSelectors: suite]