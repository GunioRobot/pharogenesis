strokeGrow: evt with: growHandle
	| dir |
	evt keyValue = 28 ifTrue:[dir _ -1@0].
	evt keyValue = 29 ifTrue:[dir _ 1@0].
	evt keyValue = 30 ifTrue:[dir _ 0@-1].
	evt keyValue = 31 ifTrue:[dir _ 0@1].
	dir ifNil:[^self].
	evt hand obtainHalo: self.
	evt hand newKeyboardFocus: growHandle.
	target extent: target extent + dir.
	self layoutChanged.