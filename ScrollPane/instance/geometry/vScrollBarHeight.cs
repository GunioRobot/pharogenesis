vScrollBarHeight
	| h |

	h _ bounds height - (2 * borderWidth).
	(retractableScrollBar not and: [self hIsScrollbarNeeded]) 
		ifTrue:[ h _ h - self scrollBarThickness. ].
	
	^h
