test5
	"FormCanvas test5"

	| canvas |
	canvas _ FormCanvas extent: 200@200.
	canvas fillColor: (Color yellow).
	canvas _ canvas copyForShadowDrawingOffset: 10@10.
	canvas line: 10@10 to: 50@30 width: 1 color: (Color blue).
	canvas frameRectangle: ((20@20) corner: (120@120)) width: 4 color: (Color red).
	canvas point: 90@90 color: (Color red).
	canvas text: 'Hello, Roxie' at: 40@40 font: nil color: (Color red).
	canvas fillRectangle: ((10@80) corner: (31@121)) color: (Color red).
	canvas fillOval: ((10@80) corner: (31@121)) color: (Color red).
	canvas fillRectangle: ((130@30) corner: (170@80)) color: (Color red).
	canvas showAt: 0@0.