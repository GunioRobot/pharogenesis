keyStroke: evt
	"Handle a keystroke event."

	| ch |
	ch _ evt keyCharacter.
	ch = Character backspace ifTrue: [  "backspace"
		contents size > 0 ifTrue: [
			self contents: (contents copyFrom: 1 to: contents size - 1)].
		^ self].
	(ch = $x and: [evt commandKeyPressed]) ifTrue: [  "cut"
		Smalltalk clipboardText: contents.
		^ self contents: ''].
	(ch = $c and: [evt commandKeyPressed]) ifTrue: [  "copy"
		Smalltalk clipboardText: contents.
		^ self].
	(ch = $v and: [evt commandKeyPressed]) ifTrue: [  "paste"
		^ self contents: Smalltalk clipboardText].
	((evt keyCharacter = Character enter) or:
	 [(evt keyCharacter = Character cr) or:
	 [evt keyCharacter = $s and: [evt commandKeyPressed]]]) ifTrue: [  "accept"
		self acceptContents.
		evt hand newKeyboardFocus: evt hand world.
		^ self].

	self contents: (contents copyWith: ch).  "append the character"
