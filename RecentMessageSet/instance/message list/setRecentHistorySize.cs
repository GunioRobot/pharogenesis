setRecentHistorySize
	"Let the user specify the recent history size"

	| aReply aNumber |
	aReply _ FillInTheBlank request: 'How many recent methods
should be maintained?' initialAnswer: Utilities numberOfRecentSubmissionsToStore asString.
	aReply isEmptyOrNil ifFalse:
		[aNumber _ aReply asNumber rounded.
		(aNumber > 1 and: [aNumber <= 1000])
			ifTrue:
				[Utilities numberOfRecentSubmissionsToStore: aNumber.
				self inform: 'Okay, ', aNumber asString, ' is the new size of the recent method history']
			ifFalse:
				[self inform: 'Sorry, must be a number between 2 & 1000']]
			