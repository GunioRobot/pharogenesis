firstPersonKeystroke: evt
	"Handle a keyboard event"
	| keyValue |
	lastCursorPoint _ evt cursorPoint.
	keyValue _ evt keyValue.
	evt shiftPressed ifTrue:[
		keyValue = 28 ifTrue:[^myCamera move: left distance: 0.25].
		keyValue = 29 ifTrue:[^myCamera move: right distance: 0.25].
		keyValue = 30 ifTrue:[^myCamera move: forward distance: 0.25].
		keyValue = 31 ifTrue:[^myCamera move: backward distance: 0.25].
	] ifFalse:[
		keyValue = 28 ifTrue:[^myCamera turn: left turns:  0.0625 duration: 0.25 style: abruptly].
		keyValue = 29 ifTrue:[^myCamera turn: right turns:  0.0625 duration: 0.25 style: abruptly].
		keyValue = 30 ifTrue:[^myCamera move: forward].
		keyValue = 31 ifTrue:[^myCamera move: backward].
	].