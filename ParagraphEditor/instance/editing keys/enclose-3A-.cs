enclose: characterStream
	"Insert or remove bracket characters around the current selection.
	 Flushes typeahead."

	| char left right startIndex stopIndex oldSelection which text |
	char _ sensor keyboard.
	self closeTypeIn.
	startIndex _ self startIndex.
	stopIndex _ self stopIndex.
	oldSelection _ self selection.
	which _ '([<{"''' indexOf: char ifAbsent: [ ^true ].
	left _ '([<{"''' at: which.
	right _ ')]>}"''' at: which.
	text _ paragraph text.
	((startIndex > 1 and: [stopIndex <= text size])
		and:
		[(text at: startIndex-1) = left and: [(text at: stopIndex) = right]])
		ifTrue:
			["already enclosed; strip off brackets"
			self selectFrom: startIndex-1 to: stopIndex.
			self replaceSelectionWith: oldSelection]
		ifFalse:
			["not enclosed; enclose by matching brackets"
			self replaceSelectionWith:
				(Text string: (String with: left), oldSelection string ,(String with: right)
					emphasis: emphasisHere).
			self selectFrom: startIndex+1 to: stopIndex].
	^true