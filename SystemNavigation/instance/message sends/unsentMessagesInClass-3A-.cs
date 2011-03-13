unsentMessagesInClass: aClass 
	|methReferences|
	methReferences := Set new.
	aClass selectors do: [:selector|
		(self isUnsentMessage: selector) ifTrue: [
			methReferences add: (MethodReference class: aClass selector: selector)]].
	^methReferences