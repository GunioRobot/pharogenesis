testFileDirectoryRootExistence
	"Hoping that you have 'C:' of course..."
	FileDirectory activeDirectoryClass == DosFileDirectory ifFalse:[^self].
	self assert: (FileDirectory root fileOrDirectoryExists: 'C:').