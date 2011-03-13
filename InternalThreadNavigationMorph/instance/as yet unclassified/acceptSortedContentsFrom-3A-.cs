acceptSortedContentsFrom: aHolder
	"Update my page list from the given page sorter."

	| nameOfThisProject |

	threadName isEmpty ifTrue: [threadName _ 'I need a name'].
	threadName _ FillInTheBlank 
		request: 'Name this thread.' 
		initialAnswer: threadName.
	threadName isEmptyOrNil ifTrue: [^self].
	listOfPages _ OrderedCollection new.
	aHolder submorphs doWithIndex: [:m :i |
		(nameOfThisProject _ m valueOfProperty: #nameOfThisProject) ifNotNil: [
			listOfPages add: {nameOfThisProject}.
		].
	].
	self class know: listOfPages as: threadName.
	self removeAllMorphs; addButtons.
	self world ifNil: [
		self openInWorld; positionAppropriately.
	].
