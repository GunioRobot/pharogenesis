loadBitBltFrom: bbObj
	"Load context from BitBlt instance.  Return false if anything is amiss"
	| ok |
	self export: true.
	bitBltOop _ bbObj.
	ok _ self loadBitBltCombinationRule.
	ok ifFalse:[^false].
	ok _ self loadBitBltDestForm.
	ok ifFalse:[^false].
	ok _ self loadBitBltDestRect.
	ok ifFalse:[^false].
	ok _ self loadBitBltSourceForm.
	ok ifFalse:[^false].
	ok _ self loadHalftoneForm.
	ok ifFalse:[^false].
	ok _ self loadBitBltClipRect.
	ok ifFalse:[^false].
	ok _ self loadFXColorMap.
	ok ifFalse:[^false].
	ok _ self loadFXSourceMap.
	ok ifFalse:[^false].
	ok _ self loadFXWarpQuad.
	ok ifFalse:[^false].
	ok _ self loadFXWarpQuality.
	ok ifFalse:[^false].
	ok _ self loadFXSourceMap.
	ok ifFalse:[^false].
	ok _ self loadFXDestMap.
	ok ifFalse:[^false].
	ok _ self loadFXAlphaValues.
	ok ifFalse:[^false].
	ok _ self loadFXTallyMap.
	ok ifFalse:[^false].
	^true