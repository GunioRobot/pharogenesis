image: aForm at: aPoint sourceRect: sourceRect rule: rule alpha: sourceAlpha
	"Draw the portion of the given Form defined by sourceRect at the given point using the given BitBlt combination rule."

	sourceForm _ aForm.
	combinationRule _ rule.
	self sourceRect: sourceRect.
	self destOrigin: aPoint.
	self copyBitsTranslucent: (alpha _ (sourceAlpha * 255) truncated min: 255 max: 0).