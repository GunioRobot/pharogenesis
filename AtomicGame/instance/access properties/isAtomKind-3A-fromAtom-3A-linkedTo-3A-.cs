isAtomKind: aKind fromAtom: aAtom linkedTo: aLink 
	| currentPosition delta |
	currentPosition _ aAtom position.
	delta _ currentMap atomSize  * aLink.
	^ self isAtomKind: aKind at: currentPosition + delta