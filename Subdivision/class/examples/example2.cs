example2	"Subdivision example2"
	"Same as example1, but this time using the outline constraints"
	| ptList subdivision |
	ptList _ ((5 to: 35) collect:[:i| i*10@50]),
			{350@75. 70@75. 70@100},
			((7 to: 35) collect:[:i| i*10@100]),
			{350@125. 50@125}.
	subdivision _ (self points: ptList) constraintOutline: ptList; yourself.
	self exampleDraw: subdivision points: ptList.
