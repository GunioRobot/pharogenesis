addSubclass: aSubclass 
	"Make the argument, aSubclass, be one of the subclasses of the receiver. 
	Create an error notification if the argument's superclass is not the 
	receiver."
	
	aSubclass superclass ~~ self 
		ifTrue: [self error: aSubclass name , ' is not my subclass']
		ifFalse: [subclasses == nil
					ifTrue:	[subclasses _ Set with: aSubclass]
					ifFalse:	[subclasses add: aSubclass]]