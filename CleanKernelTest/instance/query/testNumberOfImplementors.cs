testNumberOfImplementors
	"self run: #testNumberOfImplementors"

	self assert: (SystemNavigation new numberOfImplementorsOf: #nobodyImplementsThis) isZero.
	self assert: (SystemNavigation new numberOfImplementorsOf: #zoulouSymbol) = 2.