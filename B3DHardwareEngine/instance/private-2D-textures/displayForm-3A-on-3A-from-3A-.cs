displayForm: sourceForm on: destForm from: sourceOrigin
	"@@@ FIXME: Fix #displayOn: to use real color map if needed"
	(BitBlt toForm: destForm)
		sourceOrigin: sourceOrigin;
		sourceForm: sourceForm;
		combinationRule: 3;
		colorMap: (sourceForm colormapIfNeededFor: destForm);
		copyBits.
