setMethodListFromSearchString
	"Set the method list of the receiver based on matches from the search string"

	| fragment aList |
	self okToChange ifFalse: [^ self].
	fragment := currentQueryParameter.
	fragment := fragment asString asLowercase withBlanksTrimmed.

	aList := targetClass allSelectors select:
		[:aSelector | currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: targetClass limitClass: limitClass].
	fragment size > 0 ifTrue:
		[aList := aList select:
			[:aSelector | aSelector includesSubstring: fragment caseSensitive: false]].
	aList size == 0 ifTrue:
		[^ Beeper beep].
	self initListFrom: aList asSortedArray highlighting: targetClass.
	messageListIndex :=  messageListIndex min: messageList size.
	self changed: #messageList
