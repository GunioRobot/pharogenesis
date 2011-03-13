drawArrowsOn: aCanvas 
	"Answer (possibly modified) endpoints for border drawing"
	"ArrowForms are computed only upon demand"
	| array |
	(closed
			or: [arrows == #none
					or: [vertices size < 2]])
		ifTrue: [^ self].
	"Nothing to do"
	borderColor isColor
		ifFalse: [^ self].
	array _ Array new: 2.
	"Prevent crashes for #raised or #inset borders"
	array at: 2 put: ((arrows == #forward
			or: [arrows == #both])
		ifTrue: [ self
				drawArrowOn: aCanvas
				at: vertices last
				from: self nextToLastPoint]
		ifFalse: [ vertices last ]).
	array at: 1 put: ((arrows == #back
			or: [arrows == #both])
		ifTrue: [self
				drawArrowOn: aCanvas
				at: vertices first
				from: self nextToFirstPoint]
		ifFalse: [ vertices first ]).
	^array