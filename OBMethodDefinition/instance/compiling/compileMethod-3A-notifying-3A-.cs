compileMethod: aText notifying: aController
	^ (self confirmMethod: aText)
		ifTrue: [self theClass 
					compile: aText 
					classified: self category 
					notifying: aController]
		ifFalse: [nil]