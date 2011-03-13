layoutTopToBottom: aMorph in: newBounds
	"An optimized top-to-bottom list layout"
	| inset n size extent width height block sum vFill posX posY extra centering extraPerCell last amount minX minY maxX maxY sizeX sizeY first cell props |
	size _ properties minCellSize asPoint. minX _ size x. minY _ size y.
	size _ properties maxCellSize asPoint. maxX _ size x. maxY _ size y.
	inset _ properties cellInset asPoint y.
	extent _ newBounds extent.
	n _ 0. vFill _ false. sum _ 0.
	width _ height _ 0.
	first _ last _ nil.
	block _ [:m|
		props _ m layoutProperties ifNil:[m].
		props disableTableLayout ifFalse:[
			n _ n + 1.
			cell _ LayoutCell new target: m.
			(props vResizing == #spaceFill) ifTrue:[
				cell vSpaceFill: true.
				extra _ m spaceFillWeight.
				cell extraSpace: extra.
				sum _ sum + extra.
			] ifFalse:[cell vSpaceFill: false].
			(props hResizing == #spaceFill) ifTrue:[vFill _ true].
			size _ m minExtent. sizeX _ size x. sizeY _ size y.
			sizeX < minX
				ifTrue:[sizeX _ minX]
				ifFalse:[sizeX > maxX ifTrue:[sizeX _ maxX]].
			sizeY < minY
				ifTrue:[sizeY _ minY]
				ifFalse:[sizeY > maxY ifTrue:[sizeY _ maxY]].
			cell cellSize: sizeY.
			first ifNil:[first _ cell] ifNotNil:[last nextCell: cell].
			last _ cell.
			height _ height + sizeY.
			sizeX > width ifTrue:[width _ sizeX].
		].
	].
	properties reverseTableCells
		ifTrue:[aMorph submorphsReverseDo: block]
		ifFalse:[aMorph submorphsDo: block].

	n > 1 ifTrue:[height _ height + (n-1 * inset)].

	(properties vResizing == #shrinkWrap and:[properties rubberBandCells or:[sum isZero]])
		ifTrue:[extent _ (extent x max: width) @ height].
	(properties hResizing == #shrinkWrap and:[properties rubberBandCells or:[vFill not]])
		ifTrue:[extent _ width @ (extent y max: height)].

	posX _ newBounds left.
	posY _ newBounds top.

	"Compute extra horizontal space"
	extra _ extent x - width.
	extra < 0 ifTrue:[extra _ 0].
	extra > 0 ifTrue:[
		vFill ifTrue:[
			width _ extent x.
		] ifFalse:[
			centering _ properties wrapCentering.
			centering == #bottomRight ifTrue:[posX _ posX + extra].
			centering == #center ifTrue:[posX _ posX + (extra // 2)]
		].
	].


	"Compute extra vertical space"
	extra _ extent y - height.
	extra < 0 ifTrue:[extra _ 0].
	extraPerCell _ 0.
	extra > 0 ifTrue:[
		sum isZero ifTrue:["extra space but no #spaceFillers"
			centering _ properties listCentering.
			centering == #bottomRight ifTrue:[posY _ posY + extra].
			centering == #center ifTrue:[posY _ posY + (extra // 2)].
		] ifFalse:[extraPerCell _ extra asFloat / sum asFloat].
	].

	n _ 0.
	extra _ last _ 0.
	cell _ first.
	[cell == nil] whileFalse:[
		n _ n + 1.
		height _ cell cellSize.
		(extraPerCell > 0 and:[cell vSpaceFill]) ifTrue:[
			extra _ (last _ extra) + (extraPerCell * cell extraSpace).
			amount _ extra truncated - last truncated.
			height _ height + amount.
		].
		cell target layoutInBounds: (posX @ posY extent: width @ height).
		posY _ posY + height + inset.
		cell _ cell nextCell.
	].