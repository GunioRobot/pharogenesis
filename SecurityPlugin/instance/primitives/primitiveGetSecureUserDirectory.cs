primitiveGetSecureUserDirectory
	"Primitive. Return the secure directory for the current user."
	| dirName dirLen dirOop dirPtr |
	self export: true.
	self var: #dirName type: 'char *'.
	self var: #dirPtr type: 'char *'.
	dirName _ self cCode: 'ioGetSecureUserDirectory()' inSmalltalk: [nil].
	(dirName == nil or:[interpreterProxy failed]) 
		ifTrue:[^interpreterProxy primitiveFail].
	dirLen _ self strlen: dirName.
	dirOop _ interpreterProxy instantiateClass: interpreterProxy classString indexableSize: dirLen.
	interpreterProxy failed ifTrue:[^nil].
	dirPtr _ interpreterProxy firstIndexableField: dirOop.
	0 to: dirLen-1 do:[:i|
		dirPtr at: i put: (dirName at: i)].
	interpreterProxy pop: 1.
	interpreterProxy push: dirOop.