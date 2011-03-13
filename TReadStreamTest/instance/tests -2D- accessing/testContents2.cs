testContents2
	"From ANSI Smalltalk Standard draft 1.9: 
	
		it is unspecified whether or not the returned collection [using #contents] is the same object as the backing store collection. However, if the returned collection is not the same object as the stream backing store collection then the class of the returned collection is the same class as would be returned if the message #select: was sent to the backing store collection."
		
	"In Squeak, there is #species to know what class should be used on copy, selection..."
	| interval stream streamContents |
	interval := 1 to: 32.
	stream := self streamOn: interval.
	streamContents := stream contents.
	
	(streamContents == interval)
		ifFalse: [self assert: streamContents class = Interval new species]