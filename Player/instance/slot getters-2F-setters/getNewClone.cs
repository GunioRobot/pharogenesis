getNewClone
	"Answer a new player of the same class as the receiver, with a costume much like mine"

	| clone |
	clone _  costume usableSiblingInstance.
	costume pasteUpMorph ifNotNilDo: [:parent | parent addMorph: clone].
	^ clone player
