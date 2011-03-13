testVersionShouldParseComplexName
	| queryReference |
	queryReference := GoferVersionReference name: 'Seaside-Core-pmm.2'.
	self assert: queryReference packageName = 'Seaside-Core'.
	self assert: queryReference authorName = 'pmm'.
	self assert: queryReference branchName = ''.
	self assert: queryReference versionNumber = 2.
	
	queryReference := GoferVersionReference name: 'Seaside-Core-jf.configcleanup.3'.
	self assert: queryReference packageName = 'Seaside-Core'.
	self assert: queryReference authorName = 'jf'.
	self assert: queryReference branchName = 'configcleanup'.
	self assert: queryReference versionNumber = 3.
	
	queryReference := GoferVersionReference name: 'Seaside-Core-lr.configcleanup.extraspeedup.69'.
	self assert: queryReference packageName = 'Seaside-Core'.
	self assert: queryReference authorName = 'lr'.
	self assert: queryReference branchName = 'configcleanup.extraspeedup'.
	self assert: queryReference versionNumber = 69.

	queryReference := GoferVersionReference name: 'Seaside-Core-lr.configcleanup42.extraspeedup.69'.
	self assert: queryReference packageName = 'Seaside-Core'.
	self assert: queryReference authorName = 'lr'.
	self assert: queryReference branchName = 'configcleanup42.extraspeedup'.
	self assert: queryReference versionNumber = 69.
