morphsAt: aPoint behind: aMorph unlocked: aBool
	"Return all morphs at aPoint that are behind frontMorph; if aBool is true return only unlocked, visible morphs."
	| isBack found all tfm |
	(aMorph == nil or:[owner == nil]) ifTrue:["Traverse down"
		(self fullBounds containsPoint: aPoint) ifFalse:[^#()].
		(aBool and:[self isLocked or:[self visible not]]) ifTrue:[^#()].
		all _ nil.
	] ifFalse:[ "Traverse up"
		tfm _ self transformedFrom: owner.
		all _ owner morphsAt: (tfm localPointToGlobal: aPoint) behind: self unlocked: aBool.
		all _ WriteStream with: all.
	].
	isBack _ aMorph == nil.
	self submorphsDo:[:m|
		isBack ifTrue:[
			tfm _ m transformedFrom: self.
			found _ m morphsAt: (tfm globalPointToLocal: aPoint) behind: nil unlocked: aBool.
			found size > 0 ifTrue:[
				all ifNil:[all _ WriteStream on: #()].
				all nextPutAll: found]].
		m == aMorph ifTrue:[isBack _ true]].
	(isBack and:[self containsPoint: aPoint]) ifTrue:[
		all ifNil:[^Array with: self].
		all nextPut: self].
	^all ifNil:[#()] ifNotNil:[all contents].
