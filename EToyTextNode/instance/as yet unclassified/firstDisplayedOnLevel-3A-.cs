firstDisplayedOnLevel: level

	firstDisplay _ false.
	text addAttribute: (TextFontChange fontNumber: ((5 - level) max: 1)).
