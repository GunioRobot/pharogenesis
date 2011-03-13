selectedPackageIndex: anIndex
	self flag: #lex.  "only present in case people have existing browser windows open"
	self selectPackageOrCategory:
		(anIndex = 0 ifTrue: [ nil ] ifFalse: [ self sortedPackages at: anIndex ]).
	self changed: #selectedPackageIndex
	