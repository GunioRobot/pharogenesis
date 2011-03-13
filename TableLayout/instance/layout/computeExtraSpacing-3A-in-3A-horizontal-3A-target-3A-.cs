computeExtraSpacing: arrangement in: newBounds horizontal: aBool target: aMorph
	"Compute the required extra spacing for laying out the cells"
	| extent extra centering n extraPerCell cell last hFill vFill max amount allow |
	"match newBounds extent with arrangement's orientation"
	extent _ newBounds extent.
	aBool ifFalse:[extent _ extent transposed].

	"figure out if we have any horizontal or vertical space fillers"
	hFill _ vFill _ false.
	max _ 0@0.
	arrangement do:[:c|
		max _ (max x max: c cellSize x) @ (max y + c cellSize y).
		max _ max max: c cellSize.
		hFill _ hFill or:[c hSpaceFill].
		vFill _ vFill or:[c vSpaceFill]].

	"Take client's shrink wrap constraints into account.
	Note: these are only honored when there are no #spaceFill children,
	or when #rubberBandCells is set."
	allow _ properties rubberBandCells not.
	aMorph hResizing == #shrinkWrap ifTrue:[
		aBool 
			ifTrue:[allow & hFill ifFalse:[extent _ max x @ (max y max: extent y)]]
			ifFalse:[allow & vFill ifFalse:[extent _ (max x max: extent x) @ max y]]].
	aMorph vResizing == #shrinkWrap ifTrue:[
		aBool 
			ifFalse:[allow & hFill ifFalse:[extent _ max x @ (max y max: extent y)]]
			ifTrue:[allow & vFill ifFalse:[extent _ (max x max: extent x) @ max y]]].

	"Now compute the extra v space"
	extra _ extent y - (arrangement inject: 0 into:[:sum :c| sum + c cellSize y]).
	extra > 0 ifTrue:[
		"Check if we have any #spaceFillers"
		vFill ifTrue:[ "use only #spaceFillers"
			n _ arrangement inject: 0 into:[:sum :c| 
				c vSpaceFill ifTrue:[sum + 1] ifFalse:[sum]].
			n isZero ifFalse:[extraPerCell _ extra asFloat / n asFloat].
			extra _ last _ 0.
			arrangement do:[:c|
				c vSpaceFill ifTrue:[
					extra _ (last _ extra) + extraPerCell.
					amount _ 0 @ (extra truncated - last truncated).
					c do:[:cc| cc cellSize: cc cellSize + amount]]].
		] ifFalse:[ "no #spaceFillers; distribute regularly"
			centering _ properties wrapCentering.
			"centering == #topLeft ifTrue:[]." "add all extra space to the last cell; e.g., do nothing"
			centering == #bottomRight "add all extra space to the first cell"
				ifTrue:[arrangement first addExtraSpace: 0@extra].
			centering == #center "add 1/2 extra space to the first and last cell"
				ifTrue:[arrangement first addExtraSpace: 0@ (extra // 2)].
			centering == #justified "add extra space equally distributed to each cell"
				ifTrue:[	n _ (arrangement size - 1) max: 1.
						extraPerCell _ extra asFloat / n asFloat.
						extra _ last _ 0.
						arrangement do:[:c|
							c addExtraSpace: 0@(extra truncated - last truncated).
							extra _ (last _ extra) + extraPerCell]].
		].
	].

	"Now compute the extra space for the primary direction"
	centering _ properties listCentering.
	1 to: arrangement size do:[:i|
		cell _ (arrangement at: i).
		extra _ extent x - cell cellSize x.
		extra > 0 ifTrue:[
			"Check if we have any #spaceFillers"
			cell hSpaceFill ifTrue:[ "use only #spaceFillers"
				cell _ cell nextCell.
				n _ cell inject: 0 into:[:sum :c| 
					c hSpaceFill ifTrue:[sum + c target spaceFillWeight] ifFalse:[sum]].
				n isZero ifFalse:[extraPerCell _ extra asFloat / n asFloat].
				extra _ last _ 0.
				cell do:[:c|
					c hSpaceFill ifTrue:[
						extra _ (last _ extra) + (extraPerCell * c target spaceFillWeight).
						amount _ extra truncated - last truncated.
						c cellSize: c cellSize + (amount@0)]].
			] ifFalse:[ "no #spaceFiller; distribute regularly"
				cell _ cell nextCell.
				"centering == #topLeft ifTrue:[]" "add all extra space to the last cell; e.g., do nothing"
				centering == #bottomRight "add all extra space to the first cell"
					ifTrue:[cell addExtraSpace: extra @ 0].
				centering == #center "add 1/2 extra space to the first and last cell"
					ifTrue:[cell addExtraSpace: (extra // 2) @ 0].
				centering == #justified "add extra space equally distributed to each cell"
					ifTrue:[	n _ (cell size - 1) max: 1.
							extraPerCell _ extra asFloat / n asFloat.
							extra _ last _ 0.
							cell do:[:c|
								c addExtraSpace: (extra truncated - last truncated) @ 0.
								extra _ (last _ extra) + extraPerCell]].
			].
		].
	].