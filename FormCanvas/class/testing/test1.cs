test1
	"FormCanvas test1"

	| canvas |
	canvas _ FormCanvas extent: 200@200.
	canvas fillColor: (Color black).
	canvas line: 10@10 to: 50@30 width: 1 color: (Color red).
	canvas frameRectangle: ((20@20) corner: (120@120)) width: 4 color: (Color green).
	canvas point: 90@90 color: (Color black).
	canvas text: 'Hello, Roxie' at: 40@40 font: nil color: (Color cyan).
	canvas fillRectangle: ((10@80) corner: (31@121)) color: (Color magenta).
	canvas fillOval: ((10@80) corner: (31@121)) color: (Color cyan).
	canvas fillRectangle: ((130@30) corner: (170@80)) color: (Color lightYellow).
	canvas showAt: 0@0.