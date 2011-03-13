deleteLastTwoTiles
	"Remove the current suffix (last two tiles) in this line of tiles"
	| phrase pad goodPad |
	(phrase _ self couldRetract) ifNil: [^ self].
	pad _ phrase ownerThatIsA: TilePadMorph.
	goodPad _ phrase firstSubmorph.
	pad owner addMorphBack: goodPad.
	pad delete.
	(goodPad lastSubmorph respondsTo: #addSuffixArrow) 
		ifTrue: [goodPad lastSubmorph addSuffixArrow; addRetractArrow]
		ifFalse: [goodPad lastSubmorph lastSubmorph addSuffixArrow; addRetractArrow].
	goodPad topEditor install. "recompile"