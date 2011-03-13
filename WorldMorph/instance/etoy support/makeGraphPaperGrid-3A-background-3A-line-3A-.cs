makeGraphPaperGrid: smallGrid background: backColor line: lineColor
	| bigGrid gridForm |
	bigGrid _ 40 roundTo: smallGrid.
	gridForm _ Form extent: bigGrid asPoint depth: Display depth.
	gridForm fillWithColor: backColor.
	0 to: bigGrid by: smallGrid do:
		[:i | gridForm fill: (i@0 extent: 1@bigGrid) fillColor: lineColor.
			gridForm fill: (0@i extent: bigGrid@1) fillColor: lineColor].
	color _ InfiniteForm with: gridForm