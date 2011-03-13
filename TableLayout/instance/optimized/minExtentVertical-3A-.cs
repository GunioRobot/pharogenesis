minExtentVertical: aMorph
	"Return the minimal size aMorph's children would require given the new bounds"
	| inset n size width height minX minY maxX maxY sizeX sizeY |
	size _ properties minCellSize asPoint. minX _ size x. minY _ size y.
	size _ properties maxCellSize asPoint. maxX _ size x. maxY _ size y.
	inset _ properties cellInset asPoint.
	n _ 0.
	width _ height _ 0.
	aMorph submorphsDo:[:m|
		m disableTableLayout ifFalse:[
			n _ n + 1.
			size _ m minExtent. sizeX _ size x. sizeY _ size y.
			sizeX < minX
				ifTrue:[sizeX _ minX]
				ifFalse:[sizeX > maxX ifTrue:[sizeX _ maxX]].
			sizeY < minY
				ifTrue:[sizeY _ minY]
				ifFalse:[sizeY > maxY ifTrue:[sizeY _ maxY]].
			height _ height + sizeY.
			sizeX > width ifTrue:[width _ sizeX].
		].
	].
	n > 1 ifTrue:[height _ height + (n-1 * inset y)].
	^minExtentCache _ width @ height