versions
	"Create and schedule a changelist browser on the versions of the 
	selected message."
	| class selector method category pair sourcePointer |
	listIndex = 0 ifTrue: [^ self].
	class _ parent selectedClassOrMetaClass.
	selector _ parent selectedMessageName.
	(class includesSelector: selector)
		ifTrue: [method _ class compiledMethodAt: selector.
				category _ class whichCategoryIncludesSelector: selector.
				sourcePointer _ nil]
		ifFalse: [pair _ parent changeSet methodRemoves
							at: (Array with: class name with: selector)
							ifAbsent: [^ nil].
				sourcePointer _ pair first.
				method _ CompiledMethod toReturnSelf setSourcePointer: sourcePointer.
				category _ pair last].
	controller controlTerminate.
	ChangeList
		browseVersionsOf: method
		class: parent selectedClass meta: class isMeta
		category: category selector: selector
		lostMethodPointer: sourcePointer.
	controller controlInitialize