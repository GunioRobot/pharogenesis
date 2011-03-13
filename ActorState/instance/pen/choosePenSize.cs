choosePenSize
	| menu sz |
	menu := CustomMenu new.
	1 to: 10 do: [:w | menu add: w printString action: w].
	sz := menu startUp.
	sz ifNotNil: [penSize := sz]