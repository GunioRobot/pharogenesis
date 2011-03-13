hasDisableTableLayoutString
	self disableTableLayout
		ifTrue:[^'<on>disable layout in tables']
		ifFalse:[^'<off>disable layout in tables']