incomingObjectsClass
	"Rather HyperSqueak-specific:  Answer class that handles Incoming Objects, if present, else answer nil.  9/19/96 sw"

	| aClass |
	^ ((aClass _ Smalltalk at: #IncomingObjects ifAbsent: [nil]) isKindOf: Class)
		ifTrue:
			[aClass]
		ifFalse:
			[nil]