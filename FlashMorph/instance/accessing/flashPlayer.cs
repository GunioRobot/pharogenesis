flashPlayer
	| parent |
	parent _ owner.
	[parent isNil] whileFalse:[
		(parent isFlashMorph and:[parent isFlashPlayer]) ifTrue:[^parent].
		parent _ parent owner].
	^nil