chooseColor
	| attribute |
	"Make a new Text Color Attribute, let the user pick a color, and return the attribute"

	ColorPickerMorph new
		choseModalityFromPreference;
		sourceHand: morph activeHand;
		target: (attribute := TextColor color: Color black "default");
		selector: #color:;
		originalColor: Color black;
		putUpFor: morph near: morph fullBoundsInWorld.
	^ attribute
