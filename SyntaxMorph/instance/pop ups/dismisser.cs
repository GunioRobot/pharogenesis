dismisser
	"Return the icon to delete this line of tiles.  I am an entire line in a block."
	| handle handleSpec colorToUse iconName form |

	(owner isSyntaxMorph and: [owner nodeClassIs: BlockNode]) ifFalse: [^ nil].
	handleSpec _ Preferences haloSpecifications fourth.	"dismiss"
	handle _ EllipseMorph
			newBounds: (Rectangle center: 10@10 extent: 16 asPoint)
			color: (colorToUse _ Color colorFrom: handleSpec color).
	iconName _ handleSpec iconSymbol.
	form _ ScriptingSystem formAtKey: iconName.	"#'Halo-Dismiss'"
	handle addMorphCentered: (ImageMorph new
				image: form; 
				color: colorToUse makeForegroundColor;
				lock).
	handle on: #mouseDown send: #deleteLine to: self.
	^ handle