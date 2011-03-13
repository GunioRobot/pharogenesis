remove: aNode
	| list choice |
	list := aNode container organization listAtCategoryNamed: aNode name.
	list isEmpty ifTrue: [^ aNode remove].
	choice := OBConfirmationRequest prompt: 'Are you sure you want to
remove this category 
and all its elements?' confirm: 'Remove'.
	choice ifTrue: [^ aNode remove]