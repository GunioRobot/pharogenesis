valueSupplyingAnswers: aListOfPairs
	"evaluate the block using a list of questions / answers that might be called upon to
	automatically respond to Object>>confirm: or FillInTheBlank requests"

	^ [self value] 
		on: ProvideAnswerNotification
		do: 
			[:notify | | answer caption |
			
			caption _ notify messageText withSeparatorsCompacted. "to remove new lines"
			answer _ aListOfPairs
				detect: 
					[:each | caption = each first or:
						[caption includesSubstring: each first caseSensitive: false] or:
						[each first match: caption]]
					ifNone: [nil].
			answer
				ifNotNil: [notify resume: answer second]
				ifNil: 
					[ | outerAnswer |
					outerAnswer _ ProvideAnswerNotification signal: notify messageText.
					outerAnswer 
						ifNil: [notify resume] 
						ifNotNil: [notify resume: outerAnswer]]]