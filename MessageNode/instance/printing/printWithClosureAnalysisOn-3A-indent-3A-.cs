printWithClosureAnalysisOn: aStream indent: level
	"may not need this check anymore - may be fixed by the #receiver: change"
	special ifNil: [^aStream nextPutAll: '** MessageNode with nil special **'].

	special > 0 ifTrue:
		[^self perform: self macroPrinter with: aStream with: level].

	self printWithClosureAnalysisReceiver: receiver on: aStream indent: level.
	self printWithClosureAnalysisKeywords: selector key
		 arguments: arguments
		 on: aStream
		 indent: level