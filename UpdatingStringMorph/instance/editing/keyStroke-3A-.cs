keyStroke: evt
	"Handle a keystroke event. Accept change if enter key or Cmd-S is pressed."

	| ch |
	ch _ evt keyCharacter.
	ch = Character backspace ifTrue: [  "backspace"
		contents size > 0 ifTrue: [
			self contentsClipped: (contents copyFrom: 1 to: contents size - 1)].
		^ self].
	(ch = $x and: [evt commandKeyPressed]) ifTrue: [  "cut"
		Smalltalk clipboardText: contents.
		^ self contentsClipped: ''].
	(ch = $c and: [evt commandKeyPressed]) ifTrue: [  "copy"
		Smalltalk clipboardText: contents.
		^ self].
	(ch = $v and: [evt commandKeyPressed]) ifTrue: [  "paste"
		^ self contentsClipped: Smalltalk clipboardText].
	((evt keyCharacter = Character enter) or:
	 [(evt keyCharacter = Character cr) or:
	 [evt keyCharacter = $s and: [evt commandKeyPressed]]]) ifTrue: [  "accept"
		self informTarget.
		evt hand newKeyboardFocus: evt hand world.
		^ self].

	self contentsClipped: (contents copyWith: ch).  "append the character"
