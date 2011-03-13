selectorList: anExternalList

	self contents: ''.
	classList := #(). classListIndex := 0.
	selectorIndex := 0.
	selectorList := anExternalList.
	self changed: #messageList.
	self changed: #classList.
	Smalltalk isMorphic ifTrue: [self changed: #contents.]. 

