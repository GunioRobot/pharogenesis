isAtom: aAtom linkedTo: aLink 
	| currentPosition delta |
	currentPosition _ aAtom position.
	delta _ currentMap atomSize  * aLink.
	^ self isAtomAt: currentPosition + delta