displayForm: sourceForm on: destForm
	"@@@ FIXME: Fix #displayOn: to use real color map if needed"
	(BitBlt toForm: destForm)
		sourceForm: sourceForm;
		combinationRule: 3;
		colorMap: (sourceForm colormapIfNeededFor: destForm);
		copyBits.
