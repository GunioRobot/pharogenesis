compileMultiFieldMethod: selString type: typeString
	| source selParts |
	source := String streamContents:[:s|
		selParts := selString findTokens: ':'.
		s nextPutAll: (selParts at: 1).
		s nextPutAll: ': fields '.
		s nextPutAll: (selParts at: 2).
		s nextPutAll: ': aVRMLStream '.
		s nextPutAll: (selParts at: 3).
		s nextPutAll: ': level '.
		s nextPutAll:('
	"This method was automatically generated"
	aVRMLStream nextPut: $[.
	1 to: fields size do:[:i|
		i > 1 ifTrue:[aVRMLStream crtab: level+1].
		self storeSingleField$TYPESTRING$: (fields at: i) on: aVRMLStream indent: level+1].
	aVRMLStream nextPut:$].' copyReplaceAll:'$TYPESTRING$' with: typeString).
	].
	self compile: source classified:'multi field writing'