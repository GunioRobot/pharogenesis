setPenSize

	| menu sizes nibSize |
	menu _ CustomMenu new.
	sizes _ (0 to: 5), (6 to: 12 by: 2), (15 to: 40 by: 5).
	sizes do: [:w | menu add: w printString action: w].
	nibSize _ menu startUp.
	nibSize ifNotNil: [
		brushSize _ nibSize.
		brush roundNib: nibSize].
