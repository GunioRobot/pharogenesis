getCameraMorph
	| morph |
	morph _ owner.
	[morph == nil] whileFalse:[
		(morph isKindOf: WonderlandCameraMorph) ifTrue:[^morph].
		morph _ morph owner].
	^nil