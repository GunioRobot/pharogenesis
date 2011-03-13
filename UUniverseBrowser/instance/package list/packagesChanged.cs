packagesChanged
	self installSet initializeSelectedPackageVersions.  "the selected packages may not be there any more!"
	self selectPackageOrCategory:   nil.
	
	self changed: #packageDescriptions.  self flag: #lex.  "only for compatibility with old, open GUI windows"
	self changed: #rootCategoriesAndPackages.
	