soundUpEvt: a morph: b

	soundSlider ifNotNil: [soundSlider delete].
	soundSlider _ nil.
	Beeper beep 