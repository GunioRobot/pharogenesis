clickAt: clickPoint for: model controller: editor
	"Give sensitive text a chance to fire.  Display flash: (100@100 extent: 100@100)."
	| startBlock action target range boxes box |
	action _ false.
	startBlock _ self characterBlockAtPoint: clickPoint.
	(text attributesAt: startBlock stringIndex forStyle: textStyle) 
		do: [:att | att mayActOnClick ifTrue:
				[(target _ model) ifNil: [target _ editor morph].
				range _ text rangeOf: att startingAt: startBlock stringIndex forStyle: textStyle.
				boxes _ self selectionRectsFrom: (self characterBlockForIndex: range first) 
							to: (self characterBlockForIndex: range last+1).
				box _ boxes detect: [:each | each containsPoint: clickPoint] ifNone: [nil].
				box ifNotNil:
					[ box _ (editor transformFrom: nil) invertBoundsRect: box.
					editor morph allOwnersDo: [ :m | box _ box intersect: (m boundsInWorld) ].
					Utilities awaitMouseUpIn: box
						repeating: []
						ifSucceed: [(att actOnClickFor: target in: self at: clickPoint editor: editor) ifTrue: [action _ true]].
					Cursor currentCursor == Cursor webLink ifTrue:[Cursor normal show].
				]]].
	^ action