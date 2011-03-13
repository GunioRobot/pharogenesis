printHierarchy
	"Answer a description containing the names and instance variable names 
	of all of the subclasses and superclasses of the receiver."

	| aStream index |
	index _ 0.
	aStream _ WriteStream on: (String new: 16).
	self allSuperclasses reverseDo: 
		[:aClass | 
		aStream crtab: index.
		index _ index + 1.
		aStream nextPutAll: aClass name.
		aStream space.
		aStream print: aClass instVarNames].
	aStream cr.
	self printSubclassesOn: aStream level: index.
	^aStream contents