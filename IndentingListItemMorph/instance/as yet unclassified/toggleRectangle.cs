toggleRectangle

	| h |
	h _ bounds height.
	^(bounds left + (h * indentLevel)) @ bounds top extent: h@h