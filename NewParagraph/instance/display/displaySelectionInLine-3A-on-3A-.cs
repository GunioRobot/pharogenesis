displaySelectionInLine: line on: aCanvas
	| leftX rightX w |
	selectionStart ifNil: [^ self].  "No selection"
	selectionStart = selectionStop
		ifTrue: ["Only show caret on line where clicked"
				selectionStart textLine ~= line ifTrue: [^ self]]
		ifFalse: ["Test entire selection before or after here"
				(selectionStop stringIndex < line first
					or: [selectionStart stringIndex > (line last+1)])
					ifTrue: [^ self].  "No selection on this line"
				(selectionStop stringIndex = line first
					and: [selectionStop textLine ~= line])
					ifTrue: [^ self].  "Selection ends on line above"
				(selectionStart stringIndex = (line last+1)
					and: [selectionStop textLine ~= line])
					ifTrue: [^ self]].  "Selection begins on line below"

	selectionStart stringIndex < line first
		ifTrue: [leftX _ line left]
		ifFalse: [leftX _ selectionStart left].
	(selectionStop stringIndex > (line last+1)
			or: [selectionStop stringIndex = (line last+1)
					and: [selectionStop textLine ~= line]])
		ifTrue: [rightX _ line right]
		ifFalse: [rightX _ selectionStop left].
	selectionStart = selectionStop ifTrue:
		[rightX _ rightX + 1.
		w _ self caretWidth.
		1 to: w do:
			[:i |  "Draw caret triangles at top and bottom"
			aCanvas fillRectangle: ((leftX-w+i-1)@(line top+i-1) extent: (w-i*2+3)@1)
				color: self selectionColor.
			aCanvas fillRectangle: ((leftX-w+i-1)@(line bottom-i) extent: (w-i*2+3)@1)
				color: self selectionColor]].
	aCanvas fillRectangle: (leftX@line top corner: rightX@line bottom)
				color: self selectionColor.
