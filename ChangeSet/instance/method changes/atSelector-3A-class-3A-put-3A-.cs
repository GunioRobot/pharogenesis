atSelector: selector class: class put: changeType

	(selector == #DoIt or: [selector == #DoItIn:]) ifTrue: [^ self].
	(self changeRecorderFor: class) atSelector: selector put: changeType.
