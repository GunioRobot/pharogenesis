testFileDirectoryNonExistence
	"Hoping that you have 'C:' of course..."
	FileDirectory activeDirectoryClass == DosFileDirectory ifFalse:[^self].
	self should: [(FileDirectory basicNew fileOrDirectoryExists: 'C:')] raise: InvalidDirectoryError.