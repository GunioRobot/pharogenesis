displayChar: c
	| line |

	displayMode = #sawEscape ifTrue: [ 
		^self displayCharSawEscape: c ].

	displayMode = #gatheringParameters ifTrue: [
		^self displayCharGatheringParameters: c ].

	c = Character escape ifTrue: [
		displayMode _ #sawEscape.
		^self ].

	c = Character cr ifTrue: [
		"go back to the beginning of the line"
		cursorX _ 1.
		^self ].

	c = Character lf ifTrue: [
		"go to the next line"
		cursorY _ cursorY + 1.
		cursorY > 25 ifTrue: [
			self scrollScreenBack: 1.
			cursorY _ 25 ].
		^self ].

	c = Character tab ifTrue: [
		"move to the next tab stop"
		cursorX _ cursorX + 8 // 8 * 8.
		self possiblyWrapCursor.
		^self ].

	"default: display the character"
	line _ displayLines at: cursorY.
	line at: cursorX put: c.
	line addAttribute: (TextColor color: foregroundColor) from: cursorX to: cursorX.
		
	cursorX _ cursorX + 1.
	self possiblyWrapCursor.