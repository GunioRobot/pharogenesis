doPrintPreview

	| pageDisplay sz newPage subBounds pic align |

	sz _ (85 @ 110) * 3.
	self printSpecs landscapeFlag ifTrue: [
		sz _ sz transposed
	].
	pageDisplay _ BookMorph new
		color: Color paleYellow;
		borderWidth: 1.
	self allPages withIndexDo: [ :each :index |
		pic _ ImageMorph new image: (each pageThumbnailOfSize: sz).
		align _ AlignmentMorph newColumn
			addMorph: pic;
			borderWidth: 1;
			layoutInset: 0;
			borderColor: Color blue.
		newPage _ pageDisplay 
			insertPageLabel: 'Page ',index printString
			morphs: {align}.
		subBounds _ newPage boundingBoxOfSubmorphs.
		newPage extent: subBounds corner - newPage topLeft + ((subBounds left - newPage left)@0).
	].
	pageDisplay 
		goToPage: 1;
		deletePageBasic;
		position: Display extent - pageDisplay extent // 2;
		openInWorld.
