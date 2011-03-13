dropOnClass: aNode
	aNode theClass 
		compile: self source
		classified: (self theClass organization 
			categoryOfElement: self selector).
	InputSensor default shiftPressed
		ifFalse: [ self theClass removeSelector: self selector ].
	aNode signalChildrenChanged.
	^ true