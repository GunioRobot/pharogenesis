controlActivity
	"Any button opens the screen's menu.
	If the shift key is down, do find window."

	sensor leftShiftDown ifTrue: [^ self findWindow].
	(self projectScreenMenu invokeOn: self) ifNil: [super controlActivity]