drawOn: aCanvas 
	"Fixed bounds for now.  "

	| space rect list index |
	super drawOn: aCanvas.
	self drawSelectionsOn: aCanvas.
	space _ 1.
	rect _ self topLeft + (space@space) extent: cellSize - (1@1).
	list _ Color indexedColors.
	"list _ (1 to: 256) collect: [:ind | list at: (MineToStd at: ind)]."
	index _ 0.
	1 to: 16 do: [:x |
		1 to: 16 do: [:y |
			aCanvas fillRectangle: rect color: (list at: (index _ index + 1)).
			rect _ rect translateBy: (cellSize x @ 0)].
		rect _ self bounds left + space @ (rect top + cellSize y) extent: cellSize - (1@1).
		].
