arrowForms
	"ArrowForms are computed only upon demand"
	(closed or: [arrows == #none or: [vertices size < 2]]) ifTrue:
		[^ arrowForms _ nil].
	arrowForms ifNotNil: [^ arrowForms].
	arrowForms _ Array new.
	(arrows == #forward or: [arrows == #both]) ifTrue:
		[arrowForms _ arrowForms copyWith:
			(self computeArrowFormAt: vertices last from: self nextToLastPoint)].
	(arrows == #back or: [arrows == #both]) ifTrue:
		[arrowForms _ arrowForms copyWith:
			(self computeArrowFormAt: vertices first from: self nextToFirstPoint)].
	^ arrowForms