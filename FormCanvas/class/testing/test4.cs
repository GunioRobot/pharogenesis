test4
	"Time millisecondsToRun: [FormCanvas test4] 1134"
	"3762 mSecs -- ParcPlace Smalltalk on Duo 230"

	| baseCanvas p canvas |
	baseCanvas _ FormCanvas extent: 200@200.
	p _ Sensor cursorPoint.
	100 timesRepeat: [
		canvas _ baseCanvas copyOffset: (Sensor cursorPoint - p).
		canvas fillColor: (Color white).
		canvas line: 10@10 to: 50@30 width: 1 color: (Color black).
		canvas frameRectangle: ((20@20) corner: (120@120)) width: 4 color: (Color gray).
		canvas point: 90@90 color: (Color black).
		canvas text: 'Hello, Roxie' at: 40@40 font: nil color: (Color black).
		canvas fillRectangle: ((10@80) corner: (31@121)) color: (Color lightGray).
		canvas fillRectangle: ((130@30) corner: (170@80)) color: (Color black).
		canvas showAt: 0@0.
	].