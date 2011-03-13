highlightFrom: start to: stop
	(start == nil or: [stop == nil]) ifTrue: [^ self displayView].
	start to: stop do:
		[:i | selection := i.
		(self listSelectionAt: selection) ifTrue: [self displaySelectionBox]].
	selection := 0