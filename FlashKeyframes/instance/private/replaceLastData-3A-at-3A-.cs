replaceLastData: newData at: frameNumber
	| kf |
	lastIndex := nil.
	kf := kfList last.
	(kf stop = kf start)
		ifTrue:[kfList removeLast]
		ifFalse:[kf stop: kf stop-1].
	^self at: frameNumber put: newData