verticalGradient

	| midPt start mid stop|
	midPt := self float.
	self recognize:#( (16r0010 colorFloat) )
		do:[:color|
			start isNil ifTrue:[start := color] ifFalse:[
			mid isNil ifTrue:[mid := color] ifFalse:[
			stop isNil ifTrue:[stop := color]]]].
	^Array with: start with: mid with: stop