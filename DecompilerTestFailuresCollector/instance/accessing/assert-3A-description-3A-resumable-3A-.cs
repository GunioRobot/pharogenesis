assert: aBoolean description: aString resumable: resumableBoolean 
	aBoolean ifFalse: 
		[failures isNil ifTrue:
			[failures := OrderedCollection new].
		 failures addLast: (thisContext sender tempAt: 1) methodReference]