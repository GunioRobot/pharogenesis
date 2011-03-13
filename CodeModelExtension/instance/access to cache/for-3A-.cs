for: aClass 
	| newSendCache |
	^perClassCache at: aClass
		ifAbsent: 
			[newSendCache := self newCacheFor: aClass.
			(self haveInterestsIn: aClass) 
				ifTrue: [perClassCache at: aClass put: newSendCache].
			newSendCache]