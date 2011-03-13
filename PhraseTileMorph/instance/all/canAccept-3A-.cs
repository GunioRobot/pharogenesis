canAccept: aMorph

	"((aMorph isKindOf: PhraseTileMorph) or:
	 [aMorph isKindOf: TileMorph])"  "not allow dropping to replace now"
	(aMorph isKindOf: TileMorph) ifTrue: [
			^ aMorph resultType == resultType]. "This is never used????"
	^ false
