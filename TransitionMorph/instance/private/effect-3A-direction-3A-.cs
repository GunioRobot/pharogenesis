effect: effectSymbol direction: dirSymbol
	| i |
	effect _ effectSymbol.

	"Default directions"
	(#(zoom zoomFrame frenchDoor) includes: effectSymbol)
		ifTrue: [(#(in out inH outH) includes: dirSymbol)
					ifTrue: [direction _ dirSymbol]
					ifFalse: [direction _ #in]]
		ifFalse: [i _ #(right downRight down downLeft left upLeft up upRight)
						indexOf: dirSymbol ifAbsent: [5].
				direction _ (0@0) eightNeighbors at: i].