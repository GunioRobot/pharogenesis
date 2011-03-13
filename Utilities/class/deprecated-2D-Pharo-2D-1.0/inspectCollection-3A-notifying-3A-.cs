inspectCollection: aCollection notifying: aView

	self deprecated: 'No replacement is suggested.' on: '10 July 2009' in: #Pharo1.0.
	
	aCollection size = 0 
		ifTrue: [aView notNil 
			ifTrue: [^ aView flash]
			ifFalse: [^ self]].
	aCollection size = 1
		ifTrue: [aCollection first inspect]
		ifFalse: [aCollection asArray inspect]