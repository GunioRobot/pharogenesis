replaceLastData: newData at: frameNumber
	| kf |
	lastIndex _ nil.
	kf _ kfList last.
	(kf stop = kf start)
		ifTrue:[kfList removeLast]
		ifFalse:[kf stop: kf stop-1].
	^self at: frameNumber put: newData