update: aParameter 

	aParameter == getLabelSelector ifTrue: [
		getLabelSelector ifNotNil: [
			self label: (model perform: getLabelSelector).
			self displayView]].
	self getModelState 
		ifTrue: [self displayComplemented]
		ifFalse: [self displayNormal].
