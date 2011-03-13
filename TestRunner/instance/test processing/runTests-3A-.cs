runTests: aString
	"doIt: [TestRunner new runTests: 'Test* test*']"

	self
		classPattern: (self classPatternFrom: aString);
		selectorPattern: (self selectorPatternFrom: aString).
	self runTests.