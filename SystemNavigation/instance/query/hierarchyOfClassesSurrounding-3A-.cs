hierarchyOfClassesSurrounding: aClass
	"Answer a list of classes in the hierarchy both above and below the given class"
	"SystemNavigation default hierarchyOfClassesSurrounding: StringHolder"
	
	| list aClassNonMeta isMeta theClassOrMeta |
	aClass ifNil: [^ OrderedCollection new].
	aClass ifNil: [^ self].
	aClassNonMeta _ aClass theNonMetaClass.
	isMeta _ aClassNonMeta ~~ aClass.
	list _ OrderedCollection new.
	aClass allSuperclasses reverseDo:
		[:cl | list addLast: cl].
	aClassNonMeta allSubclassesWithLevelDo:
		[:cl :level |
		theClassOrMeta _ isMeta ifTrue: [cl class] ifFalse: [cl].
		list addLast: theClassOrMeta]
	 	startingLevel: 0.
	^ list

