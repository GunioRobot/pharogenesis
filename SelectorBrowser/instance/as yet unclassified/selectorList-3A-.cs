selectorList: anExternalList

	self contents: ''.
	classList _ #(). classListIndex _ 0.
	selectorIndex _ 0.
	selectorList _ anExternalList.
	self changed: #messageList.
	self changed: #classList.
	Smalltalk isMorphic ifTrue: [self changed: #contents.]. 

