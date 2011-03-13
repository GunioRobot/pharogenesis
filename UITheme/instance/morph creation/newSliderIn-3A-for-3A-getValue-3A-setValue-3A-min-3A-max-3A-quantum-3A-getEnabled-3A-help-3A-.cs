newSliderIn: aThemedMorph for: aModel getValue: getSel setValue: setSel min: min max: max quantum: quantum getEnabled: enabledSel help: helpText
	"Answer a slider."

	^(PluggableSliderMorph
			on: aModel
			getValue: getSel
			setValue: setSel
			min: min
			max: max
			quantum: quantum)
		getEnabledSelector: enabledSel;
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		setBalloonText: helpText