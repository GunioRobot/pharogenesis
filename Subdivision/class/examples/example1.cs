example1	"Subdivision example1"
	| ptList subdivision |
	ptList _ ((5 to: 35) collect:[:i| i*10@50]),
			{350@75. 70@75. 70@100},
			((7 to: 35) collect:[:i| i*10@100]),
			{350@125. 50@125}.
	subdivision _ self points: ptList.
	self exampleDraw: subdivision points: ptList.
