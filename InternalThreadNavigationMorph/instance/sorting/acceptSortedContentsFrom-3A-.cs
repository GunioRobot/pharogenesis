acceptSortedContentsFrom: aHolder
	"Update my page list from the given page sorter."

	| nameOfThisProject cachedData proj |

	threadName isEmpty ifTrue: [threadName _ 'I need a name' translated].
	threadName _ FillInTheBlank 
		request: 'Name this thread.' translated 
		initialAnswer: threadName.
	threadName isEmptyOrNil ifTrue: [^self].
	listOfPages _ OrderedCollection new.
	aHolder submorphs doWithIndex: [:m :i |
		(nameOfThisProject _ m valueOfProperty: #nameOfThisProject) ifNotNil: [
			cachedData _ {nameOfThisProject}.
			proj _ Project named: nameOfThisProject.
			(proj isNil or: [proj thumbnail isNil]) ifFalse: [
				cachedData _ cachedData, {proj thumbnail scaledToSize: self myThumbnailSize}.
			].
			listOfPages add: cachedData.
		].
	].
	self class know: listOfPages as: threadName.
	self removeAllMorphs; addButtons.
	self world ifNil: [
		self openInWorld; positionAppropriately.
	].
