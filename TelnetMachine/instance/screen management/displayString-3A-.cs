displayString: aString
	"add aString to the display"
	|pos specialIdx |

	pos _ 1. 	"pos steps through aString"

	[ pos <= aString size ] whileTrue: [
		displayMode = #normal ifTrue: [
			"try to display a whole hunk of text at once"
			specialIdx _ aString indexOfAnyOf: CSSpecialChars startingAt: pos ifAbsent: [ aString size + 1 ].
			specialIdx > pos ifTrue: [
				self addBoringStringInNormalMode: (aString copyFrom: pos to: specialIdx-1).
				pos _ specialIdx. ] ].

			pos <= aString size ifTrue: [
				"either a special has been seen, or we're in a special mode"
				self displayChar: (aString at: pos).
				pos _ pos + 1. ].
	].

