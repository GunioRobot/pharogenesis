setIndexInOwner: anInteger
	"Answer which position the receiver holds in its owner's hierarchy"

	"There is some concern about submorphs that aren't really to be counted, such as a background morph of a playfield."
	| container topRenderer indexToUse |
	container _ (topRenderer _ self topRendererOrSelf) owner.
	indexToUse _ (anInteger min: container submorphCount) max: 1.
	container addMorph: topRenderer asElementNumber: indexToUse