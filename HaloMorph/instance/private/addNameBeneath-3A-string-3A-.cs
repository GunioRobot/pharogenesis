addNameBeneath: outerRectangle string: aString
	"Add a name display centered beneath the bottom of the outer rectangle. Return the handle."

	| nameMorph namePosition w |
	w _ self world ifNil:[target world].
	nameMorph _ NameStringInHalo contents: aString font: Preferences standardHaloLabelFont.
	nameMorph color: Color black.
	nameMorph useStringFormat; target: innerTarget; putSelector: #tryToRenameTo:.
	namePosition _ outerRectangle bottomCenter -
		((nameMorph width // 2) @ (self handleSize negated // 2 - 1)).
	nameMorph position: (namePosition min: w viewBox bottomRight - nameMorph extent y + 2).
	nameMorph balloonTextSelector: #objectNameInHalo.
	self addMorph: nameMorph.
	^ nameMorph