selectionRectsFrom: characterBlock1 to: characterBlock2 
	"Return an array of rectangles representing the area between the two character blocks given as arguments."
	| line1 line2 rects cb1 cb2 w |
	characterBlock1 <= characterBlock2
		ifTrue: [cb1 _ characterBlock1.  cb2 _ characterBlock2]
		ifFalse: [cb2 _ characterBlock1.  cb1 _ characterBlock2].
	cb1 = cb2 ifTrue:
		[w _ self caretWidth.
		^ Array with: (cb1 topLeft - (w@0) corner: cb1 bottomLeft + ((w+1)@0))].
	line1 _ self lineIndexForCharacter: cb1 stringIndex.
	line2 _ self lineIndexForCharacter: cb2 stringIndex.
	line1 = line2 ifTrue:
		[^ Array with: (cb1 topLeft corner: cb2 bottomLeft)].
	rects _ OrderedCollection new.
	rects addLast: (cb1 topLeft corner: (lines at: line1) bottomRight).
	line1+1 to: line2-1 do: [:i | rects addLast: (lines at: i) rectangle].
	rects addLast: ((lines at: line2) topLeft corner: cb2 bottomLeft).
	^ rects