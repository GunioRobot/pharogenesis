remove: oldObject ifAbsent: exceptionBlock
	"Remove oldObject as one of the receiver's elements."
	| removedObject |
	oldObject ifNil: [^oldObject].
	self protected:[
		removedObject := valueDictionary removeKey: oldObject ifAbsent: [nil].
	].
	^removedObject
		ifNil: [exceptionBlock value]
		ifNotNil: [removedObject].
