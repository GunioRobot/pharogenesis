fullDrawOn: aCanvas

	running ifFalse: [^ super fullDrawOn: (aCanvas copyClipRect: (bounds translateBy: aCanvas origin))].
	(aCanvas isVisible: bounds) ifTrue: [self drawOn: aCanvas].
