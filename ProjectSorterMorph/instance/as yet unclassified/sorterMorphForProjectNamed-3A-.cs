sorterMorphForProjectNamed: projName

	| pvm proj |

	(proj _ Project named: projName) ifNil: [^nil].
	pvm _ (InternalThreadNavigationMorph getThumbnailFor: proj) asMorph.
	pvm setProperty: #nameOfThisProject toValue: projName.
	pvm setBalloonText: projName.
	pvm on: #mouseDown send: #clickFromSorterEvent:morph: to: self.
	pvm on: #mouseUp send: #clickFromSorterEvent:morph: to: self.
	^pvm

