showFormsDictAcrossTopOfScreen: formDict
	"Display the given Dictionary of forms across the top of the screen, wrapping to subsequent lines if needed.  Beneath each, put the name of the associated key."

	"Utilities showFormsDictAcrossTopOfScreen: HaloIcons"

	| position maxHeight screenBox ceiling elem box h labelWidth keyString |

	position _ 20.
	maxHeight _ 0.
	ceiling _ 0.
	screenBox _ Display boundingBox.
	formDict associationsDo:
		[:assoc | (elem _ assoc value) displayAt: (position @ ceiling).
			box _ elem boundingBox.
			h _ box height.
			keyString _ (assoc key isKindOf: String) ifTrue: [assoc key] ifFalse: [assoc key printString].
			keyString displayAt: (position @ (ceiling + h)).
			labelWidth _ TextStyle default defaultFont widthOfString: keyString.
			maxHeight _ maxHeight max: h.
			position _ position + (box width max: labelWidth) + 5.
			position > (screenBox right - 100) ifTrue:
				[position _ 20.
				ceiling _ ceiling + maxHeight + 15.
				maxHeight _ 0]]