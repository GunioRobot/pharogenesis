initializeRuleTable
	"BitBltSimulation initializeRuleTable"
	OpTable _ #(
		"0" clearWord:with:
		"1" bitAnd:with:
		"2" bitAndInvert:with:
		"3" sourceWord:with:
		"4" bitInvertAnd:with:
		"5" destinationWord:with:
		"6" bitXor:with:
		"7" bitOr:with:
		"8" bitInvertAndInvert:with:
		"9" bitInvertXor:with:
		"10" bitInvertDestination:with:
		"11" bitOrInvert:with:
		"12" bitInvertSource:with:
		"13" bitInvertOr:with:
		"14" bitInvertOrInvert:with:
		"15" destinationWord:with:
		"16" destinationWord:with:
		"17" destinationWord:with:
		"18" addWord:with:
		"19" subWord:with:
		"20" rgbAdd:with:
		"21" rgbSub:with:
		"22" rgbDiff:with:
		"23" tallyIntoMap:with:
		"24" alphaBlend:with:
		"25" pixPaint:with:
		"26" pixMask:with:
		"27" rgbMax:with:
		"28" rgbMin:with:
		"29" rgbMinInvert:with:
		"30" destinationWord:with:
		"31" destinationWord:with:
	).
	OpTableSize _ OpTable size + 1.  "0-origin indexing"
