arrowForms
	"ArrowForms are computed only upon demand"
	arrowForms ifNotNil: [^ arrowForms].

	arrowForms _ Array new.
	(closed or: [arrows == #none or: [vertices size < 2]]) ifTrue:
		[^ arrowForms].
	(arrows == #forward or: [arrows == #both]) ifTrue:
		[arrowForms _ arrowForms copyWith:
			(self computeArrowFormAt: vertices last from: self nextToLastPoint)].
	(arrows == #back or: [arrows == #both]) ifTrue:
		[arrowForms _ arrowForms copyWith:
			(self computeArrowFormAt: vertices first from: self nextToFirstPoint)].
	^ arrowForms