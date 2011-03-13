contents
	"Depending on the current selection, different information is retrieved.
	Answer a string description of that information. This information is the
	method of the currently selected class and message."
	| comment theClass |
	editSelection == #none ifTrue: [^ ''].
	editSelection == #editSystemCategories 
		ifTrue: [^ systemOrganizer printString].
	editSelection == #newClass 
		ifTrue: [^ Class template: self selectedSystemCategoryName].
	editSelection == #editClass 
		ifTrue: [^ self selectedClassOrMetaClass definition].
	editSelection == #editComment 
		ifTrue: [(theClass _ self selectedClass) ifNil: [^ ''].
				comment _ theClass comment.
				comment size = 0
				ifTrue: [ ^ 'This class has not yet been commented.']
				ifFalse: [ ^ comment]].
	editSelection == #hierarchy 
		ifTrue: [^ self selectedClassOrMetaClass printHierarchy].
	editSelection == #editMessageCategories 
		ifTrue: [^ self classOrMetaClassOrganizer printString].
	editSelection == #newMessage
		ifTrue: [^ self selectedClassOrMetaClass sourceCodeTemplate].
	editSelection == #editMessage
		ifTrue: [^ self selectedMessage].
	editSelection == #byteCodes ifTrue: [
		^ (self selectedClassOrMetaClass compiledMethodAt: 
				self selectedMessageName) symbolic asText].

	self error: 'Browser internal error: unknown edit selection.'