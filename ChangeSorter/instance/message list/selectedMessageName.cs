selectedMessageName
	| sel |
	^ (sel _ messageList selection) == nil ifFalse: [sel asSymbol]
		ifTrue: [nil]