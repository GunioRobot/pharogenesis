cursorHome: characterStream 

	"Private - Move cursor from position in current line to beginning of
	current line. If control key is pressed put cursor at beginning of text"

	| string |

	string _ paragraph text string.
	self
		moveCursor: [ :position | Preferences wordStyleCursorMovement
				ifTrue:[
					(paragraph lines at:(paragraph lineIndexOfCharacterIndex: position)) first]
				ifFalse:[
					(string
						lastIndexOf: Character cr
						startingAt: position - 1
						ifAbsent:[0]) + 1]]
		forward: false
		specialBlock: [:dummy | 1].
	^true