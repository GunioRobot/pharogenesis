test3
	"FormCanvas test3"

	| canvas |
	canvas _ FormCanvas extent: 200@200.
	canvas fillOval: ((10@80) corner: (31@121)) color: (Color cyan).
	canvas frameOval: ((40@80) corner: (61@121)) color: (Color blue).
	canvas frameOval: ((70@80) corner: (91@121)) width: 3 color: (Color red).
	canvas fillRectangle: ((130@30) corner: (170@80)) color: (Color lightYellow).
	canvas showAt: 0@0.