unusedClasses
	"Warning: Slow! Enumerates all classes in the system and returns a list of those that are apparently unused. A class is considered in use if it (a) has subclasses (b) has instances or (c) is referred to by some method. Obsolete classes are not included in this list."
	"Smalltalk unusedClasses"

	| unused c n |
	unused _ SortedCollection new.

'Scanning for unused classes...'
	displayProgressAt: Sensor cursorPoint
	from: 0 to: Metaclass instanceCount
	during: [:bar | n _ 0.

	Metaclass allInstancesDo: [:meta | bar value: (n _ n+1).
		c _ meta soleInstance.
		((c ~~ nil) and:
		 [('AnOb*' match: c name asString) not]) ifTrue: [
			((c subclasses size = 0) and:
			 [(c inheritsFrom: FileDirectory) not & (c instanceCount = 0) and:
			 [(Smalltalk includesKey: c name) and: [(Smalltalk allCallsOn: (Smalltalk associationAt: c name)) size = 0]]])
				ifTrue: [unused add: c name]]]].

	^ unused asArray
