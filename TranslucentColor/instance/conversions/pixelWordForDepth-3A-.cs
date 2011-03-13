pixelWordForDepth: depth
	depth < 32 ifTrue: [^ super pixelWordForDepth: depth].
	^ (super pixelWordForDepth: depth) bitOr: (alpha bitShift: 24)