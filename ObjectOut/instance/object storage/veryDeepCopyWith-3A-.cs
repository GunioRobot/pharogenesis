veryDeepCopyWith: deepCopier
	"Copy me and the entire tree of objects I point to.  An object in the tree twice is copied once, and both references point to him.  deepCopier holds a dictionary of objects we have seen.  Some classes refuse to be copied.  Some classes are picky about which fields get deep copied."
	| class index sub subAss new absent |
	new _ deepCopier references at: self ifAbsent: [absent _ true].
	absent ifNil: [^ new].	"already done"
	class _ self xxxClass.
	class isMeta ifTrue: [^ self].		"a class"
	new _ self xxxClone.
	"not a uniClass"
	deepCopier references at: self put: new.	"remember"
	"class is not variable"
	index _ class instSize.
	[index > 0] whileTrue: 
		[sub _ self xxxInstVarAt: index.
		(subAss _ deepCopier references associationAt: sub ifAbsent: [nil])
			ifNil: [new xxxInstVarAt: index put: (sub veryDeepCopyWith: deepCopier)]
			ifNotNil: [new xxxInstVarAt: index put: subAss value].
		index _ index - 1].
	new rehash.	"force Sets and Dictionaries to rehash"
	^ new
