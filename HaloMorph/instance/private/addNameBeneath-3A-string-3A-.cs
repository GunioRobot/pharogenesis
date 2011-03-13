addNameBeneath: outerRectangle string: aString
	"Add a name display centered beneath the bottom of the outer rectangle. Return the handle."

	| nameMorph |
	nameMorph _ UpdatingStringMorph contents: aString.
	nameMorph useStringFormat; target: innerTarget; putSelector: #renameTo:.
	nameMorph position: outerRectangle bottomCenter - (((nameMorph width + 6) // 2) @ 8 negated).
	nameMorph balloonTextSelector: #objectNameInHalo.
	self addMorph: nameMorph.
	^ nameMorph