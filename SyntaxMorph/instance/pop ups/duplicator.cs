duplicator
	"Return the icon to duplicate this tile."
	| handle handleSpec colorToUse iconName form |

	handleSpec _ Preferences haloSpecifications at: 11.	"duplicate"
	handle _ EllipseMorph
			newBounds: (Rectangle center: 10@10 extent: 16 asPoint)
			color: (colorToUse _ Color colorFrom: handleSpec color).
	iconName _ handleSpec iconSymbol.
	form _ ScriptingSystem formAtKey: iconName.	"#'Halo-Dup'"
	handle addMorphCentered: (ImageMorph new
				image: form; 
				color: colorToUse makeForegroundColor;
				lock).
	handle on: #mouseDown send: #dupTile: to: self.
	^ handle