flapTab
	| ww |
	self isFlap ifFalse:[^nil].
	ww _ self world ifNil: [World].
	^ww flapTabs detect:[:any| any referent == self] ifNone:[nil]