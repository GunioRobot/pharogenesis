addNameBeneath: outerRectangle string: aString
	"Add a name display centered beneath the bottom of the outer rectangle. Return the handle."

	| nameMorph namePosition |
	nameMorph _ NameStringInHalo contents: aString.
	nameMorph color: Color magenta.
	nameMorph useStringFormat; target: innerTarget; putSelector: #renameTo:.
	namePosition _ outerRectangle bottomCenter -
		((nameMorph width // 2) @ (self handleSize negated // 2 - 1)).
	nameMorph position: (namePosition min: self world viewBox bottomRight - nameMorph extent y + 2).
	nameMorph balloonTextSelector: #objectNameInHalo.
	self addMorph: nameMorph.
	^ nameMorph