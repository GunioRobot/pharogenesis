oldFileOrNoneNamed: fileName
	"Only open the file if it exists already.  Don't get an error if not there.  "

| myName |
myName _ self fullName: fileName.
^ (self concreteStream isAFileNamed: myName) 
	ifTrue: [self concreteStream oldFileNamed: myName]
	ifFalse: [nil].