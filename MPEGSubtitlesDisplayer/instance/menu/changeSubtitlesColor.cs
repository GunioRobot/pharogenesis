changeSubtitlesColor
	"offer a ColorPicker to change the subtitles colors"

	ColorPickerMorph new
		choseModalityFromPreference;
		sourceHand: self activeHand;
		target: self;
		selector: #textColor:;
		originalColor: self textColor;
		putUpFor: self currentHand near: self currentHand cursorBounds
