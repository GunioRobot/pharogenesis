clickAt: clickPoint for: model controller: aController
	"Give sensitive text a chance to fire.  Display flash: (100@100 extent: 100@100)."
	| startBlock action range box boxes |
	action _ false.
	startBlock _ self characterBlockAtPoint: clickPoint.
	(text attributesAt: startBlock stringIndex forStyle: textStyle) 
		do: [:att | att mayActOnClick ifTrue:
				[range _ text rangeOf: att startingAt: startBlock stringIndex.
				boxes _ self selectionRectsFrom: (self characterBlockForIndex: range first) 
							to: (self characterBlockForIndex: range last+1).
				box _ boxes detect: [:each | each containsPoint: clickPoint]
							ifNone: [^ action].
				Utilities awaitMouseUpIn: box repeating: []
					ifSucceed: [aController terminateAndInitializeAround:
								[(att actOnClickFor: model in: self at: clickPoint editor: aController) ifTrue: [action _ true]]]]].
	^ action