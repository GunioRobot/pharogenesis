inspectAt: aPoint event: evt
	| menu morphs target |
	menu _ CustomMenu new.
	morphs _ self morphsAt: aPoint.
	(morphs includes: self) ifFalse:[morphs _ morphs copyWith: self].
	morphs do: [:m | 
		menu add: (m knownName ifNil:[m class name asString]) action: m].
	target _ menu startUpWithCaption: ('inspect whom?
(deepest at top)').
	target ifNil:[^self].
	target inspectInMorphic: evt