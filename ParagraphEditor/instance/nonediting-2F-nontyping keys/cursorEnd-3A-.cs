cursorEnd: characterStream 

	"Private - Move cursor end of current line."
	| string |
	self closeTypeIn: characterStream.
	string _ paragraph text string.
	self
		moveCursor:
			[:position | Preferences wordStyleCursorMovement
				ifTrue:[| targetLine |
					targetLine _ paragraph lines at:(paragraph lineIndexOfCharacterIndex: position).
					targetLine = paragraph lines last
						ifTrue:[targetLine last + 1]
						ifFalse:[targetLine last]]
				ifFalse:[
					string
						indexOf: Character cr
						startingAt: position
						ifAbsent:[string size + 1]]]
		forward: true
		specialBlock:[:dummy | string size + 1].
	^true