selectedPackageIndex
	self flag: #lex.  "only present in case people have existing browser windows open"
	^self sortedPackages indexOf: selectedPackage