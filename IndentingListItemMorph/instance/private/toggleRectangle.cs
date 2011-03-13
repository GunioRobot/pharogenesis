toggleRectangle

	| h |
	h _ bounds height.
	^(bounds left + (12 * indentLevel)) @ bounds top extent: 12@h