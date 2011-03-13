testQueryShouldFindLatestVersion
	| queryReference versionReference |
	queryReference := GoferConstraintReference name: 'Gofer' repository: self goferRepository.
	versionReference := queryReference versionReference.
	self assert: versionReference packageName = 'Gofer'.
	self assert: versionReference versionNumber > 20.
	self assert: versionReference branchName = ''.
	
	queryReference constraintBlock: [ :ref | ref versionNumber < 20 ].
	versionReference := queryReference versionReference.
	self assert: versionReference packageName = 'Gofer'.
	self assert: versionReference versionNumber = 19.
	self assert: versionReference authorName = 'lr'.
	self assert: versionReference branchName = ''.
	
	queryReference constraintBlock: [ :ref | ref versionNumber < 20 and: [ ref authorName = 'tg' ] ].
	versionReference := queryReference versionReference.
	self assert: versionReference packageName = 'Gofer'.
	self assert: versionReference versionNumber = 10.
	self assert: versionReference authorName = 'tg'.
	self assert: versionReference branchName = ''
	
