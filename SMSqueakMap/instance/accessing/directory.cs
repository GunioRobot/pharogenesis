directory
	"Return the subdirectory that SqueakMap uses."
	
	(FileDirectory default directoryExists: dir)
		ifFalse:[FileDirectory default createDirectory: dir].
	^FileDirectory default directoryNamed: dir