selectMessage
	| messages sel |
	messages := self messageSelectors copyWithFirst: selector.
	sel := (OBChoiceRequest labels: messages).
	^ sel ifNotNil: [OBMessageNode on: sel inMethodNode: self]