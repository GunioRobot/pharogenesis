deal
	| card |
	self cards size > 0 
		ifTrue: [
			card _ self topCard.
			card delete.
			^card]
		ifFalse: [^nil]