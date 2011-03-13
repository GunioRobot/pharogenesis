setLayout: layout in: widget
	layout == #proportional ifTrue:[^self].
	layout == #horizontal ifTrue:[
		| prev |
		prev := nil.
		widget subViews do:[:next|
			prev ifNotNil:[
				next align: next viewport topLeft with: prev viewport topRight.
			].
			prev := next.
		].
		^self].
	layout == #vertical ifTrue:[
		| prev |
		prev := nil.
		widget subViews do:[:next|
			prev ifNotNil:[
				next align: next viewport topLeft with: prev viewport bottomLeft.
			].
			prev := next.
		].
		^self].
	^self error: 'Unknown layout: ', layout.