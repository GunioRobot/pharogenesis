classNameOf: aClass Is: className 
	"Check if aClass' name is className"
	| srcName name length |
	self var: #className declareC: 'char *className'.
	self var: #srcName declareC: 'char *srcName'.
	(self lengthOf: aClass) <= 6 ifTrue: [^ false].

	"Not a class but maybe behavior"
	name _ self fetchPointer: 6 ofObject: aClass.
	(self isBytes: name) ifFalse: [^ false].
	length _ self stSizeOf: name.
	srcName _ self cCoerce: (self arrayValueOf: name) to: 'char *'.
	0 to: length - 1 do: [:i | (srcName at: i) = (className at: i) ifFalse: [^ false]].
	"Check if className really ends at this point"
	^ (className at: length) = 0