localeChanged
	| caption |
	caption := ColorPickerMorph noColorCaption.
	caption displayOn: ColorChart at: ColorChart boundingBox topCenter - (caption width // 2 @ 0)