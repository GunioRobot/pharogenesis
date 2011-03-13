morphsForMyContentsSizedTo: sz

	| allMorphicProjects morphsForPageSorter proj pvm |

	allMorphicProjects _ Project allMorphicProjects.
	'Assembling thumbnail images...'
		displayProgressAt: self cursorPoint
		from: 0 to: listOfPages size
		during: [:bar |
			morphsForPageSorter _ listOfPages withIndexCollect: [ :each :index | 
				bar value: index.
				(proj _ Project named: each first in: allMorphicProjects) ifNil: [
					nil
				] ifNotNil: [
					pvm _ ProjectViewMorph on: proj.
					pvm _ pvm imageForm scaledToSize: sz.
					pvm _ pvm asMorph.
					pvm setProperty: #nameOfThisProject toValue: each first.
					pvm setBalloonText: each first.
					pvm on: #mouseDown send: #clickFromSorterEvent:morph: to: self.
					pvm on: #mouseUp send: #clickFromSorterEvent:morph: to: self.
					pvm
				]
			].
		].
	^morphsForPageSorter
