sameColumn: start newLine: lineBlock forward: isForward
	"Private - Compute the index in my text
	with the line number derived from lineBlock,"
	" a one argument block accepting the old line number.
	The position inside the line will be preserved as good as possible"
	"The boolean isForward is used in the border case to determine if
	we should move to the beginning or the end of the line."
	| wordStyle column currentLine offsetAtTargetLine targetEOL lines numberOfLines currentLineNumber targetLineNumber |
	wordStyle _ Preferences wordStyleCursorMovement.
	wordStyle
		ifTrue: [
			lines _ paragraph lines.
			numberOfLines := paragraph numberOfLines.
			currentLineNumber  _ paragraph lineIndexOfCharacterIndex: start.
			currentLine _ lines at: currentLineNumber]
		ifFalse: [
			lines _ self lines.
			numberOfLines := lines size.
			currentLine _ lines
				detect:[:lineInterval | lineInterval last >= start]
				ifNone:[lines last].
			currentLineNumber _ currentLine second].
	column _ start - currentLine first.
	targetLineNumber _ ((lineBlock value: currentLineNumber) max: 1) min: numberOfLines.
	offsetAtTargetLine _ (lines at: targetLineNumber) first.
	targetEOL _ (lines at: targetLineNumber) last + (targetLineNumber == numberOfLines ifTrue:[1]ifFalse:[0]).
	targetLineNumber == currentLineNumber
	"No movement or movement failed. Move to beginning or end of line."
		ifTrue:[^isForward
			ifTrue:[targetEOL]
			ifFalse:[offsetAtTargetLine]].
	^offsetAtTargetLine + column min: targetEOL.