wantsDroppedMorph: aMorph event: evt 
	"Answer whether the receiver would be interested in accepting the morph"

	(submorphs detect: [:m | m isAlignmentMorph] ifNone: [nil]) 
		ifNotNil: [^ false].

	((aMorph isKindOf: ParameterTile) and: [aMorph scriptEditor == self topEditor])
		ifTrue: [^ true].
	^ (aMorph isKindOf: PhraseTileMorph orOf: WatcherWrapper) 
		and: [(#(#Command #Unknown) includes: aMorph resultType capitalized) not]