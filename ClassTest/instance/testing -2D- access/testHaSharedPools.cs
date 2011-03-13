testHaSharedPools
	"self run: #testHaSharedPools"

	self deny: Point hasSharedPools.
	self assert: Date hasSharedPools