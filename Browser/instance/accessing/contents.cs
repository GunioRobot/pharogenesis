contents
	"Depending on the current selection, different information is retrieved.
	Answer a string description of that information. This information is the
	method of the currently selected class and message."

	| comment theClass latestCompiledMethod |
	latestCompiledMethod _ currentCompiledMethod.
	currentCompiledMethod _ nil.

	editSelection == #newTrait
		ifTrue: [^Trait newTemplateIn: self selectedSystemCategoryName].
	editSelection == #none ifTrue: [^ ''].
	editSelection == #editSystemCategories 
		ifTrue: [^ systemOrganizer printString].
	editSelection == #newClass 
		ifTrue: [^ (theClass _ self selectedClass)
			ifNil:
				[Class template: self selectedSystemCategoryName]
			ifNotNil:
				[Class templateForSubclassOf: theClass category: self selectedSystemCategoryName]].
	editSelection == #editClass 
		ifTrue: [^self classDefinitionText].
	editSelection == #editComment 
		ifTrue:
			[(theClass _ self selectedClass) ifNil: [^ ''].
			comment _ theClass comment.
			currentCompiledMethod _ theClass organization commentRemoteStr.
			^ comment size = 0
				ifTrue: ['This class has not yet been commented.']
				ifFalse: [comment]].
	editSelection == #hierarchy 
		ifTrue: [
			self selectedClassOrMetaClass isTrait
				ifTrue: [^'']
				ifFalse: [^self selectedClassOrMetaClass printHierarchy]].
	editSelection == #editMessageCategories 
		ifTrue: [^ self classOrMetaClassOrganizer printString].
	editSelection == #newMessage
		ifTrue:
			[^ (theClass _ self selectedClassOrMetaClass) 
				ifNil: ['']
				ifNotNil: [theClass sourceCodeTemplate]].
	editSelection == #editMessage
		ifTrue:
			[self showingByteCodes ifTrue: [^ self selectedBytecodes].
			currentCompiledMethod _ latestCompiledMethod.
			^ self selectedMessage].

	self error: 'Browser internal error: unknown edit selection.'