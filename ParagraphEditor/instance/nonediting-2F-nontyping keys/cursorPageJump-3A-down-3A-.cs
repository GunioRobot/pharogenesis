cursorPageJump: characterStream down: aBoolean
"Private - Move cursor from position in current line to same position in the line on the next page up or down (direction is controlled by <aBoolean>. If next line too short, put at end. If shift key down, select.  This method is similar to #cursorDown:.  Haven't figured out how to intercept the shift key yet.

See Utilities createPageTestWorkspace to create a test MVC workspace."

	| string right left start position textSize currentLineNumber howManyLines visibleHeight totalHeight ratio deltaLines targetLine offsetAtTargetLine |
	self closeTypeIn: characterStream.
	sensor keyboard.  "Eat the key stroke."
	string _ paragraph text string.
	textSize _ string size.
	left _ right _ stopBlock stringIndex.
	"Calculate the position of the left edge."
	[left > 1 and: [(string at: (left - 1)) ~= Character cr]] whileTrue: [left _ left - 1].
	"Calculate the offset from the left edge where cursor is now."
	position _ stopBlock stringIndex - left.
	"Calculate the current line number."
	currentLineNumber _ paragraph lineIndexOfCharacterIndex: stopBlock stringIndex.
	howManyLines _ paragraph numberOfLines.
	visibleHeight _ self visibleHeight.
	totalHeight _ self totalTextHeight.
	ratio _ visibleHeight / totalHeight.
	deltaLines _ (ratio * howManyLines) rounded - 2.
	targetLine _ aBoolean
		ifTrue: [(currentLineNumber + deltaLines) min: howManyLines]
		ifFalse: [(currentLineNumber - deltaLines) max: 1].
	offsetAtTargetLine _ (paragraph lines at: targetLine) first.
	"Calculate the position of the right edge of text of target line."
	right _ offsetAtTargetLine.
	[right < textSize and: [(string at: right) ~= Character cr]] whileTrue: [right _ right + 1].
	start _ offsetAtTargetLine.
	start + position > right
			ifTrue: [self selectForTopFrom: right to: right - 1]
			ifFalse: [self selectForTopFrom: start + position to: start + position - 1].
	^true