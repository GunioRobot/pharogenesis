hasStructureOfComplexWatcher
	"Answer whether the receiver has precisely the structure of a so-called complex watcher, as used in the etoy system."

	| top |
	top := (self owner ifNil: [^ false]) owner.
	^ ((((top isMemberOf: AlignmentMorph)
		and: [top submorphs size = 4])
			and: [top submorphs first isMemberOf: TileMorph])
				and: [top submorphs third isMemberOf: AlignmentMorph])