clickAt: clickPoint for: model controller: editor
	"Give sensitive text a chance to fire.  Display flash: (100@100 extent: 100@100)."
	| startBlock action target |
	action _ false.
	startBlock _ self characterBlockAtPoint: clickPoint.
	(text attributesAt: startBlock stringIndex forStyle: textStyle) 
		do: [:att | att mayActOnClick ifTrue:
				[
	"			range _ text rangeOf: att startingAt: startBlock stringIndex.
				boxes _ self selectionRectsFrom: (self characterBlockForIndex: range first) 
							to: (self characterBlockForIndex: range last).
				box _ boxes detect: [:each | each containsPoint: clickPoint].
					*This doesn't work in morphic*
				Need to replace by a highlighting morph that waits for moueUp.
				Utilities awaitMouseUpIn: (editor transform invertRect: box)
						repeating: []
						ifSucceed: [(att actOnClickFor: model) ifTrue: [action _ true]].
	"
				(target _ model) ifNil: [target _ editor morph].
				(att actOnClickFor: target)
					ifTrue: [Sensor waitNoButton.  "FIX THIS"
							action _ true]]].
	^ action