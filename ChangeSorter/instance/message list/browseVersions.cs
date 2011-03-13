browseVersions
	"Create and schedule a changelist browser on the versions of the 
	selected message."
	| class selector method category pair sourcePointer |

	(selector _ self selectedMessageName) ifNil: [^ self].
	class _ self selectedClassOrMetaClass.
	(class includesSelector: selector)
		ifTrue: [method _ class compiledMethodAt: selector.
				category _ class whichCategoryIncludesSelector: selector.
				sourcePointer _ nil]
		ifFalse: [pair _ myChangeSet methodRemoves
							at: (Array with: class name with: selector)
							ifAbsent: [^ nil].
				sourcePointer _ pair first.
				method _ CompiledMethod toReturnSelf setSourcePointer: sourcePointer.
				category _ pair last].
	ChangeList
		browseVersionsOf: method
		class: self selectedClass meta: class isMeta
		category: category selector: selector
		lostMethodPointer: sourcePointer.
