playfield
	| fields |
	standardPlayfield ifNotNil: [standardPlayfield isInWorld ifTrue: [^ standardPlayfield]].

	fields _ associatedMorph submorphs select: [:m | m isPlayfieldLike].
	fields do: [:m | (m externalName beginsWith: 'playfield') ifTrue:
		[standardPlayfield _ m.
		^ m]].

	^ m size > 0 ifTrue: [standardPlayfield _ m first] ifFalse: [associatedMorph]