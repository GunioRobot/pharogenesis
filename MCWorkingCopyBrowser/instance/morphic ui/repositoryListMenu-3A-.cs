repositoryListMenu: aMenu
	self repository ifNil: [^ aMenu].
	self fillMenu: aMenu fromSpecs:
		#(('open repository' #openRepository)
		    ('edit repository info' #editRepository)
		   ('add to package...' #addRepositoryToPackage)
		   ('remove repository' #removeRepository)	
		   ('load repositories' #loadRepositories)	
		   ('save repositories' #saveRepositories)	).
		aMenu
		add: (self repository alwaysStoreDiffs
					ifTrue: ['store full versions']
					ifFalse: ['store diffs'])
		target: self
		selector: #toggleDiffs.
	^ aMenu
				