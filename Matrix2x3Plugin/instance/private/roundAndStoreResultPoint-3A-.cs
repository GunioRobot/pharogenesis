roundAndStoreResultPoint: nItemsToPop
	"Store the result of a previous operation.
	Fail if we cannot represent the result as SmallInteger"
	m23ResultX _ m23ResultX + 0.5.
	m23ResultY _ m23ResultY + 0.5.
	(self okayIntValue: m23ResultX) ifFalse:[^interpreterProxy primitiveFail].
	(self okayIntValue: m23ResultY) ifFalse:[^interpreterProxy primitiveFail].
	interpreterProxy pop: nItemsToPop.
	interpreterProxy push:
		(interpreterProxy makePointwithxValue: m23ResultX asInteger 
							yValue: m23ResultY asInteger).