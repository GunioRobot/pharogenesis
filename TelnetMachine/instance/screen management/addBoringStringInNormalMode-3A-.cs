addBoringStringInNormalMode: aString
	"add a string with no special characters, and assuming we are already in #normal mode"
	|line inPos space amt |

aString do: [ :c | self displayChar: c ].
true ifTrue: [ ^self ].
	line _ displayLines at: cursorY.
	inPos _ 1.

	[ inPos <= aString size ] whileTrue: [
		"copy a line's worth"
		space _ 80 - cursorX + 1.
		amt _ space min: (aString size - inPos + 1).
		line replaceFrom: cursorX to: cursorX+amt-1 with: aString startingAt: inPos.
		line addAttribute: (TextColor color: foregroundColor) from: cursorX to: cursorX+amt-1.
		inPos _ inPos + amt.

		"update cursor"
		cursorX _ cursorX + amt.
		self possiblyWrapCursor.

	].
