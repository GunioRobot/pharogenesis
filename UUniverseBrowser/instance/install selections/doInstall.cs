doInstall
	self installSet anyPackageSelected ifFalse: [
		^self inform: 'no packages selected to install' ].

	self installSet doInstall.	
	
	self changed: #packageDescriptions.
	self changed: #rootCategoriesAndPackages.
