highlightFrom: start to: stop
	(start == nil or: [stop == nil]) ifTrue: [^ self displayView].
	start to: stop do:
		[:i | selection _ i.
		(model listSelectionAt: selection) ifTrue: [self displaySelectionBox]].
	selection _ 0