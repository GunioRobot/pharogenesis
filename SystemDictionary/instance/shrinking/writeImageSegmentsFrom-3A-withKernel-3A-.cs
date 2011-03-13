writeImageSegmentsFrom: segmentDictionary withKernel: kernel
	"segmentDictionary is associates segmentName -> {classNames. methodNames},
	and kernel is another set of classNames determined to be essential.
	Add a partition, 'Secondary' with everything not in partitions and not in the kernel.
	Then write segments based on this partitioning of classes."

	| metas secondary dups segDict overlaps classes n symbolHolder |
	"First, put all classes that are in no other partition, and not in kernel into a new partition called 'Secondary'.  Also remove any classes in kernel from putative partitions."
	secondary _ Smalltalk classNames asIdentitySet.
	segmentDictionary keysDo:
		[:segName |
		secondary removeAllFoundIn: (segmentDictionary at: segName) first.
		(segmentDictionary at: segName) first removeAllFoundIn: kernel].
	secondary removeAllFoundIn: kernel.
	secondary removeAllFoundIn: #(PseudoContext TranslatedMethod Utilities Preferences OutOfScopeNotification FakeClassPool  BlockCannotReturn FormSetFont ExternalSemaphoreTable NetNameResolver ScreenController InterpreterPlugin Command WeakSet).
	FileDirectory allSubclassesDo: [:c | secondary remove: c name ifAbsent: []].
	segmentDictionary at: 'Secondary' put: {secondary. {}}.

	"Now build segDict giving className -> segName, and report any duplicates."
	dups _ Dictionary new.
	segDict _ IdentityDictionary new: 3000.
	segmentDictionary keysDo:
		[:segName | (segmentDictionary at: segName) first do:
			[:className |
			(segDict includesKey: className) ifTrue:
				[(dups includesKey: className) ifFalse: [dups at: className put: Array new].
				dups at: className put: (dups at: className) , {segName}].
			segDict at: className put: segName]].
	dups size > 0 ifTrue: [dups inspect.  ^ self error: 'Duplicate entries'].

	"Then for every class in every partition, make sure that neither it
	nor any of its superclasses are in any other partition.  If they are,
	enter them in a dictionary of overlaps.
	If the dictionary is not empty, then stop and report it."
	overlaps _ Dictionary new.
	segmentDictionary keysDo:
		[:segName |  
		classes _ (segmentDictionary at: segName) first asArray collect: [:k | Smalltalk at: k].
		classes do:
			[:c | (c isKindOf: Class) ifTrue:
				[c withAllSuperclasses do:
					[:sc | n _ segDict at: sc name ifAbsent: [segName].
					n ~= segName ifTrue:
						[n = 'Secondary'
							ifTrue: [(segmentDictionary at: 'Secondary') first
										remove: sc name ifAbsent: []]
							ifFalse: [overlaps at: c name put: 
										(c withAllSuperclasses collect: [:cc | segDict associationAt: cc name ifAbsent: [cc name -> 'Kernel']])]]]]]].
	overlaps size > 0 ifTrue: [overlaps inspect.  ^ self error: 'Superclasses in separate segments'].

	"If there are no overlaps, then proceed to write the partitioned classes."
	symbolHolder _ Symbol allInstances.	"Hold onto Symbols with strong pointers, 
		so they will be in outPointers"
	segmentDictionary keysDo:
		[:segName |  Utilities informUser: segName during:
			[classes _ (segmentDictionary at: segName) first asArray collect: [:k | Smalltalk at: k].
			metas _ classes select: [:c | c isKindOf: Class] thenCollect: [:c | c class].
			(ImageSegment new copyFromRoots: classes , metas sizeHint: 0) extract; 
					writeToFile: segName]].
	symbolHolder.  "Keep compiler for getting uppity."