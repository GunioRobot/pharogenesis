hResizeScrollBar

	| topLeft h border |

"TEMPORARY: IF OLD SCROLLPANES LYING AROUND THAT DON'T HAVE A hScrollBar, INIT THEM"
	hScrollBar ifNil: [ self hInitScrollBarTEMPORARY].
	
	(self valueOfProperty: #noHScrollBarPlease ifAbsent: [false]) ifTrue: [^self].
	bounds ifNil: [ self fullBounds ].
	
	h _ self scrollBarThickness.
	border _ borderWidth.
	
	topLeft _ retractableScrollBar
				ifTrue: [bounds bottomLeft + (border @ border negated)]
				ifFalse: [bounds bottomLeft + (border @ (h + border) negated)].

	hScrollBar bounds: (topLeft extent: self hScrollBarWidth@ h)
