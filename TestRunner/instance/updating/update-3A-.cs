update: aParameter 
	"updates come in from another thread"
	(aParameter isKindOf: TestCase)
		ifTrue:[completedTests _ completedTests + 1.
				self updateProgressWatcher: aParameter printString]
		ifFalse: [ super update: aParameter ]