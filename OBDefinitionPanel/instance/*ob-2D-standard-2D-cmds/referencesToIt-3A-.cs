referencesToIt: aClassName 
	| class |
	class := self selectedClass environment at: aClassName ifAbsent: [^false].
	class isBehavior ifFalse: [^false].
	OBReferencesBrowser browseRoot: (OBClassNode on: class).
	^true