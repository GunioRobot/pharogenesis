initializeString
	| xStart char glyph |
	(font isNil or: [string isNil]) ifTrue: [^ self].
	xStart _ 0.
	ttBounds _ 0@0 corner: 0@0.
	1 to: string size do:
		[:i |
		char _ string at: i.
		glyph _ font at: char.
		ttBounds _ ttBounds quickMerge: (glyph bounds translateBy: xStart@0).
		xStart _ xStart + glyph advanceWidth.
	].
	self extent: ttBounds extent // 40.
	borderWidth _ ttBounds height // 40