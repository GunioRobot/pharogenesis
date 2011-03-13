newDefaultSettings
	"Answer a new original default settings."

	^super newDefaultSettings
		standardColorsOnly: true;
		autoSelectionColor: false;
		buttonColor: (Color r: 232 g: 232 b: 232 range: 255);
		windowColor: (Color r: 232 g: 232 b: 232 range: 255);
		scrollbarColor: (Color r: 62 g: 142 b: 220 range: 255);
		selectionColor: (Color r: 62 g: 142 b: 220 range: 255);
		progressBarColor: (Color r: 232 g: 232 b: 232 range: 255);
		progressBarProgressColor: (Color r: 62 g: 142 b: 220 range: 255)