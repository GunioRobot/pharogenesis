list: anArray 
	super list: anArray.
	list numberOfLines = 3 ifTrue: [
		controller isNil ifFalse: [
			controller changeModelSelection: 1]].
