setMethodListFromSearchString
	"Set the method list of the receiver based on matches from the search string"

	| fragment aList |
	self okToChange ifFalse: [^ self].
	fragment _ currentQueryParameter.
	fragment _ fragment asString asLowercase withBlanksTrimmed.

	aList _ targetClass allSelectors select:
		[:aSelector | currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass].
	fragment size > 0 ifTrue:
		[aList _ aList select:
			[:aSelector | aSelector includesSubstring: fragment caseSensitive: false]].
	aList size == 0 ifTrue:
		[^ Beeper beep].
	self initListFrom: aList asSortedArray highlighting: targetClass.
	messageListIndex _  messageListIndex min: messageList size.
	self changed: #messageList
