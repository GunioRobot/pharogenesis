registerBreakableIndex

	"Record left x and character index of the line-wrappable point. 
	Used for wrap-around. Answer whether the character has crossed the 
	right edge of the composition rectangle of the paragraph."

	(text at: lastIndex) = Character space ifTrue: [
		breakAtSpace _ true.
		spaceX _ destX.
		spaceCount _ spaceCount + 1.
		lineHeightAtBreak _ lineHeight.
		baselineAtBreak _ baseline.
		breakableIndex _ lastIndex.
		destX > rightMargin ifTrue: 	[^self crossedX].
	] ifFalse: [
		breakAtSpace _ false.
		lineHeightAtBreak _ lineHeight.
		baselineAtBreak _ baseline.
		breakableIndex _ lastIndex - 1.
	].
	^ false.
