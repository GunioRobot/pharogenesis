drawToggleOn: aCanvas in: aRectangle

	| aForm centeringOffset |
	complexContents hasContents ifFalse: [^self].
	aForm _ isExpanded 
		ifTrue: [container expandedForm]
		ifFalse: [container notExpandedForm].
	centeringOffset _ ((aRectangle height - aForm extent y) / 2) asInteger.
	^aCanvas 
		paintImage: aForm 
		at: (aRectangle topLeft translateBy: 0 @ centeringOffset).
