versionList
	| list children text |
	list _ OrderedCollection new.
	children _ true.
	self versionInfos do:
		[:ea |
		text _ ea name asText.
		self addAttributesToText: text for: ea.
		ea = versionInfo
			ifTrue: [children _ false]
			ifFalse:
				[children
					ifTrue: [self addAttributesToText: text forChild: ea]
					ifFalse: [self addAttributesToText: text forParent: ea]].
		list add: text].
	^ list