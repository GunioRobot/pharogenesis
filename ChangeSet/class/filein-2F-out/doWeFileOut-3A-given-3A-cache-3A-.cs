doWeFileOut: aClass given: aSet cache: cache
	| aClassAllSuperclasses aClassSoleInstanceAllSuperclasses |

	aClassAllSuperclasses := cache at: aClass
		ifAbsent: [cache at: aClass put: aClass allSuperclasses asArray].
	(aSet includesAnyOf: aClassAllSuperclasses) ifTrue: [^false].
	aClass isMeta ifFalse: [^true].
	(aSet includes: aClass soleInstance) ifTrue: [^false].
	aClassSoleInstanceAllSuperclasses := cache at: aClass soleInstance
		ifAbsent: [cache at: aClass soleInstance put: aClass soleInstance allSuperclasses asArray].
	(aSet includesAnyOf: aClassSoleInstanceAllSuperclasses) ifTrue: [^false].
	^true