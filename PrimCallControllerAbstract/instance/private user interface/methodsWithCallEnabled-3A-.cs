methodsWithCallEnabled: enabledFlag 
	^ enabledFlag
		ifNil: [self methodsWithCall]
		ifNotNil: [enabledFlag
				ifTrue: [self methodsWithEnabledCall]
				ifFalse: [self methodsWithDisabledCall]]