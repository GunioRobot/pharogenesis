performParsingLoop
	| action actionType |
	
	[self getNextToken.
	action := self actionForCurrentToken.
	action = self acceptAction] 
			whileFalse: 
				[actionType := action bitAnd: self actionMask.
				action := action bitShift: -2.
				actionType == self shiftAction 
					ifTrue: [self shift: action]
					ifFalse: 
						[actionType == self reduceAction 
							ifTrue: [self reduce: action]
							ifFalse: [self handleError: action]]].
	self checkForErrors