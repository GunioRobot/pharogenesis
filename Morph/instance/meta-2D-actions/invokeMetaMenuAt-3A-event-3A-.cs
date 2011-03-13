invokeMetaMenuAt: aPoint event: evt
	| menu morphs target |
	menu _ CustomMenu new.
	morphs _ self morphsAt: aPoint.
	(morphs includes: self) ifFalse:[morphs _ morphs copyWith: self].
	morphs size = 1 ifTrue:[morphs first invokeMetaMenu: evt].
	morphs do: [:m | 
		menu add: (m knownName ifNil:[m class name asString]) action: m].
	target _ menu startUp.
	target ifNil:[^self].
	target invokeMetaMenu: evt