autoLineLayoutString
	^ self autoLineLayout
		ifTrue:
			['stop doing auto-line-layout']
		ifFalse:
			['start doing auto-line-layout']
