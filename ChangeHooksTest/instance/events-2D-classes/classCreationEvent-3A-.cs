classCreationEvent: event 

	| classCreated |
	self addSingleEvent: event.
	classCreated := Smalltalk classNamed: self newlyCreatedClassName.
	self assert: classCreated notNil.
	self 
		assert: ((Smalltalk organization 
				listAtCategoryNamed: #'System-Change Notification') 
					includes: self newlyCreatedClassName).
	self 
		checkEvent: event
		kind: #Added
		item: classCreated
		itemKind: AbstractEvent classKind