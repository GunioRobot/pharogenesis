defineAliasAccessorsFor: fieldName type: type
	"Define read/write accessors for the given field"
	| code refClass argName |
	(type isVoid and:[type isPointerType not]) ifTrue:[^self].
	refClass _ type referentClass.
	code _ String streamContents:[:s|
		s 
			nextPutAll: fieldName; crtab;
			nextPutAll:'"This method was automatically generated"'; crtab.
		refClass == nil 
			ifTrue:[(type isAtomic and:[type isPointerType not]) 
				ifTrue:[s nextPutAll:'^handle']
				ifFalse:[s nextPutAll:'^ExternalData fromHandle: handle'.
						type isPointerType ifTrue:[s nextPutAll:' asExternalPointer'].
						s nextPutAll:' type: ';
						nextPutAll: type externalTypeName]]
			ifFalse:[s nextPutAll:'^', refClass name,' fromHandle: handle'.
					type isPointerType ifTrue:[s nextPutAll:' asExternalPointer']]].
	self compile: code classified: 'accessing'.

	code _ String streamContents:[:s|
		argName _ refClass == nil 
			ifTrue:[(type isAtomic and:[type isPointerType not])
				ifTrue:['anObject']
				ifFalse:['anExternalData']]
			ifFalse:['a',refClass name].
		s
			nextPutAll: fieldName,': '; nextPutAll: argName; crtab;
			nextPutAll:'"This method was automatically generated"'; crtab.
		(refClass == nil and:[type isAtomic and:[type isPointerType not]])
			ifTrue:[s nextPutAll:'handle _ ', argName]
			ifFalse:[s nextPutAll:'handle _ ', argName,' getHandle'.
					type isPointerType ifTrue:[s nextPutAll:' asByteArrayPointer']]].
	self compile: code classified: 'accessing'.