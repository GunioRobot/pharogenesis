veryDeepCopyWith: deepCopier
	"Copy me and the entire tree of objects I point to.  An object in the tree twice is copied once, and both references point to him.  deepCopier holds a dictionary of objects we have seen.  Some classes refuse to be copied.  Some classes are picky about which fields get deep copied."
	| class index sub subAss new uc sup has mine |
	deepCopier references at: self ifPresent: [:newer | ^ newer]. 	"already did him"
	class _ self class.
	class isMeta ifTrue: [^ self].		"a class"
	new _ self clone.
	(class isSystemDefined not and: [deepCopier newUniClasses "allowed"]) ifTrue: [
		uc _ deepCopier uniClasses at: class ifAbsent: [nil].
		uc ifNil: [
			deepCopier uniClasses at: class put: (uc _ self copyUniClassWith: deepCopier).
			deepCopier references at: class put: uc].	"remember"
		new _ uc new.
		new copyFrom: self].	"copy inst vars in case any are weak"
	deepCopier references at: self put: new.	"remember"
	(class isVariable and: [class isPointers]) ifTrue: 
		[index _ self basicSize.
		[index > 0] whileTrue: 
			[sub _ self basicAt: index.
			(subAss _ deepCopier references associationAt: sub ifAbsent: [nil])
				ifNil: [new basicAt: index put: (sub veryDeepCopyWith: deepCopier)]
				ifNotNil: [new basicAt: index put: subAss value].
			index _ index - 1]].
	"Ask each superclass if it wants to share (weak copy) any inst vars"
	new veryDeepInner: deepCopier.		"does super a lot"

	"other superclasses want all inst vars deep copied"
	sup _ class.  index _ class instSize.
	[has _ sup compiledMethodAt: #veryDeepInner: ifAbsent: [nil].
	has _ has ifNil: [class isSystemDefined not "is a uniClass"] ifNotNil: [true].
	mine _ sup instVarNames.
	has ifTrue: [index _ index - mine size]	"skip inst vars"
		ifFalse: [1 to: mine size do: [:xx |
				sub _ self instVarAt: index.
				(subAss _ deepCopier references associationAt: sub ifAbsent: [nil])
						"use association, not value, so nil is an exceptional value"
					ifNil: [new instVarAt: index put: 
								(sub veryDeepCopyWith: deepCopier)]
					ifNotNil: [new instVarAt: index put: subAss value].
				index _ index - 1]].
	(sup _ sup superclass) == nil] whileFalse.
	new rehash.	"force Sets and Dictionaries to rehash"
	^ new
