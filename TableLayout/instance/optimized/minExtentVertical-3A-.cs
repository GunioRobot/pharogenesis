minExtentVertical: aMorph 
	"Return the minimal size aMorph's children would require given the new bounds"

	| inset n size width height minX minY maxX maxY sizeX sizeY |
	size := properties minCellSize asPoint.
	minX := size x.
	minY := size y.
	size := properties maxCellSize asPoint.
	maxX := size x.
	maxY := size y.
	inset := properties cellInset asPoint.
	n := 0.
	width := height := 0.
	aMorph submorphsDo: 
			[:m | 
			m disableTableLayout 
				ifFalse: 
					[n := n + 1.
					size := m minExtent.
					sizeX := size x.
					sizeY := size y.
					sizeX < minX 
						ifTrue: [sizeX := minX]
						ifFalse: [sizeX := sizeX min: maxX].
					sizeY < minY 
						ifTrue: [sizeY := minY]
						ifFalse: [sizeY := sizeY min: maxY].
					height := height + sizeY.
					sizeX > width ifTrue: [width := sizeX]]].
	n > 1 ifTrue: [height := height + ((n - 1) * inset y)].
	^minExtentCache := width @ height