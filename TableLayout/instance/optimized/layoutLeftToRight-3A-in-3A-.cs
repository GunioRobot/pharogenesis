layoutLeftToRight: aMorph in: newBounds
	"An optimized left-to-right list layout"
	| inset n size extent width height block sum vFill posX posY extra centering extraPerCell last amount minX minY maxX maxY sizeX sizeY first cell props |
	size _ properties minCellSize asPoint. minX _ size x. minY _ size y.
	size _ properties maxCellSize asPoint. maxX _ size x. maxY _ size y.
	inset _ properties cellInset asPoint x.
	extent _ newBounds extent.
	n _ 0. vFill _ false. sum _ 0.
	width _ height _ 0.
	first _ last _ nil.
	block _ [:m|
		props _ m layoutProperties ifNil:[m].
		props disableTableLayout ifFalse:[
			n _ n + 1.
			cell _ LayoutCell new target: m.
			(props hResizing == #spaceFill) ifTrue:[
				cell hSpaceFill: true.
				extra _ m spaceFillWeight.
				cell extraSpace: extra.
				sum _ sum + extra.
			] ifFalse:[cell hSpaceFill: false].
			(props vResizing == #spaceFill) ifTrue:[vFill _ true].
			size _ m minExtent.
			size _ m minExtent. sizeX _ size x. sizeY _ size y.
			sizeX < minX
				ifTrue:[sizeX _ minX]
				ifFalse:[sizeX > maxX ifTrue:[sizeX _ maxX]].
			sizeY < minY
				ifTrue:[sizeY _ minY]
				ifFalse:[sizeY > maxY ifTrue:[sizeY _ maxY]].
			cell cellSize: sizeX.
			last ifNil:[first _ cell] ifNotNil:[last nextCell: cell].
			last _ cell.
			width _ width + sizeX.
			sizeY > height ifTrue:[height _ sizeY].
		].
	].
	properties reverseTableCells
		ifTrue:[aMorph submorphsReverseDo: block]
		ifFalse:[aMorph submorphsDo: block].

	n > 1 ifTrue:[width _ width + (n-1 * inset)].

	(properties hResizing == #shrinkWrap and:[properties rubberBandCells or:[sum isZero]])
		ifTrue:[extent _ width @ (extent y max: height)].
	(properties vResizing == #shrinkWrap and:[properties rubberBandCells or:[vFill not]])
		ifTrue:[extent _ (extent x max: width) @ height].

	posX _ newBounds left.
	posY _ newBounds top.

	"Compute extra vertical space"
	extra _ extent y - height.
	extra < 0 ifTrue:[extra _ 0].
	extra > 0 ifTrue:[
		vFill ifTrue:[
			height _ extent y.
		] ifFalse:[
			centering _ properties wrapCentering.
			centering == #bottomRight ifTrue:[posY _ posY + extra].
			centering == #center ifTrue:[posY _ posY + (extra // 2)]
		].
	].


	"Compute extra horizontal space"
	extra _ extent x - width.
	extra < 0 ifTrue:[extra _ 0].
	extraPerCell _ 0.
	extra > 0 ifTrue:[
		sum isZero ifTrue:["extra space but no #spaceFillers"
			centering _ properties listCentering.
			centering == #bottomRight ifTrue:[posX _ posX + extra].
			centering == #center ifTrue:[posX _ posX + (extra // 2)].
		] ifFalse:[extraPerCell _ extra asFloat / sum asFloat].
	].

	n _ 0.
	extra _ last _ 0.
	cell _ first.
	[cell == nil] whileFalse:[
		n _ n + 1.
		width _ cell cellSize.
		(extraPerCell > 0 and:[cell hSpaceFill]) ifTrue:[
			extra _ (last _ extra) + (extraPerCell * cell extraSpace).
			amount _ extra truncated - last truncated.
			width _ width + amount.
		].
		cell target layoutInBounds: (posX @ posY extent: width @ height).
		posX _ posX + width + inset.
		cell _ cell nextCell.
	].
