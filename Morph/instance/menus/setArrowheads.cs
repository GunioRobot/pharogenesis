setArrowheads
	"Let the user edit the size of arrowheads for this object"

	| aParameter result  |
	aParameter _ self renderedMorph valueOfProperty:  #arrowSpec ifAbsent:
		[Preferences parameterAt: #arrowSpec ifAbsent: [5 @ 4]].
	result _ Morph obtainArrowheadFor: 'Head size for arrowheads: ' translated defaultValue: aParameter asString.
	result ifNotNil:
			[self renderedMorph  setProperty: #arrowSpec toValue: result]
		ifNil:
			[Beeper beep]