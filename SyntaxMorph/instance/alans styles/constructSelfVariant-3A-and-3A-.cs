constructSelfVariant: receiver and: key

	| wordy |
	(receiver isKindOf: VariableNode) ifFalse: [^nil].
	receiver name = 'self'  ifFalse: [^nil].
	(wordy _ self translateFromWordySelfVariant: key) ifNil: [^nil].
	^wordy

