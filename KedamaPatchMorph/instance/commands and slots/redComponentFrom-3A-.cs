redComponentFrom: another

	| pix anotherPix |
	0 to: self height - 1 do: [:y |
		0 to: self width -1 do: [:x |
			pix _ self pixelAtX: x y: y.
			anotherPix _ (another pixelAtX: x y: y) bitAnd: 16rFF.
			pix _ (pix bitAnd: 16r00FFFF) bitOr: (anotherPix bitShift: 16).
			self pixelAtX: x y: y put: pix.
		].
	].
