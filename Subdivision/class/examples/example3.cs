example3	"Subdivision example3"
	"Same as example2 but marking edges"
	| ptList subdivision |
	ptList _ ((5 to: 35) collect:[:i| i*10@50]),
			{350@75. 70@75. 70@100},
			((7 to: 35) collect:[:i| i*10@100]),
			{350@125. 50@125}.
	subdivision _ (self points: ptList) constraintOutline: ptList; yourself.
	subdivision markExteriorEdges.
	self exampleDraw: subdivision points: ptList.
