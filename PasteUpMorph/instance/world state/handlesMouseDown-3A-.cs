handlesMouseDown: evt

	self isWorldMorph
		ifTrue: [^ true]
		ifFalse: [^ super handlesMouseDown: evt]
