didCodeChangeElsewhere
	| aClass aSelector |
	"Determine whether the code for the currently selected method and class has been changed somewhere else."

	currentCompiledMethod ifNil: [^ false].
	(aClass _ self selectedClassOrMetaClass) ifNil: [^ false].
	(aSelector _ self selectedMessageName) ifNil: [^ false].
	^ (aClass compiledMethodAt: aSelector ifAbsent: [nil]) ~~ currentCompiledMethod
	