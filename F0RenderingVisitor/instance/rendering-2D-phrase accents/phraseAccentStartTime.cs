phraseAccentStartTime
	| syl |
	syl _ nil.
	(phrase ifNil: [clause phrases last]) syllablesDo: [ :each | (syl isNil or: [syl isAccented]) ifTrue: [syl _ each]].
	^ self timeForEvent: syl events last