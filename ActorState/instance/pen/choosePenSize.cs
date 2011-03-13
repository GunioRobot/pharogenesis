choosePenSize
	| menu sz |
	menu _ CustomMenu new.
	1 to: 10 do: [:w | menu add: w printString action: w].
	sz _ menu startUp.
	sz ifNotNil: [penSize _ sz]