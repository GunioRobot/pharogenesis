addWorkingCopy
	|name|
	name _ FillInTheBlankMorph request: 'Name of package:'.
	name isEmptyOrNil ifFalse:
		[PackageInfo registerPackageName: name.
		workingCopy _ MCWorkingCopy forPackage: (MCPackage new name: name).
		self repositorySelection: 0].
	self changed: #workingCopyList; changed: #workingCopySelection; changed: #repositoryList