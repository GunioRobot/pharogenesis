drawArrowsOn: aCanvas
	"ArrowForms are computed only upon demand"
	(closed or: [arrows == #none or: [vertices size < 2]]) ifTrue:
		[^ self]. "Nothing to do"
	borderColor isColor ifFalse:[^self]. "Prevent crashes for #raised or #inset borders"
	(arrows == #forward or: [arrows == #both]) 
		ifTrue:[self drawArrowOn: aCanvas at: vertices last from: self nextToLastPoint].
	(arrows == #back or: [arrows == #both])
		ifTrue:[self drawArrowOn: aCanvas at: vertices first from: self nextToFirstPoint].
