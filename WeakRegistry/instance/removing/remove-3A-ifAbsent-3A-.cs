remove: oldObject ifAbsent: exceptionBlock
	"Remove oldObject as one of the receiver's elements."
	| removedObject |
	oldObject isNil ifTrue:[^oldObject].
	self protected:[
		removedObject := valueDictionary removeKey: oldObject ifAbsent:[nil].
	].
	^removedObject isNil
		ifTrue:[exceptionBlock value]
		ifFalse:[removedObject].
