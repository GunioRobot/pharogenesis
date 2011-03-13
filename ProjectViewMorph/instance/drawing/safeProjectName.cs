safeProjectName

	| projectName |
	projectName _ self valueOfProperty: #SafeProjectName ifAbsent: ['???'].
	self isTheRealProjectPresent ifFalse: [^ projectName].
	self setProperty: #SafeProjectName toValue: project name.
	^project name
