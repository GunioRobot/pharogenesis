changeTableLayout
	| layout |
	((layout _ self layoutPolicy) notNil and:[layout isTableLayout])
		ifTrue:[^self]. "already table layout"
	self layoutPolicy: TableLayout new.
	self layoutChanged.