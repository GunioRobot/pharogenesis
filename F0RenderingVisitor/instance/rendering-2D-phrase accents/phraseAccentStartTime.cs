phraseAccentStartTime
	| syl |
	syl := nil.
	(phrase ifNil: [clause phrases last]) syllablesDo: [ :each | (syl isNil or: [syl isAccented]) ifTrue: [syl := each]].
	^ self timeForEvent: syl events last