fontToUse

	| fontToUse |
	fontToUse _ font == nil
		ifTrue: [TextStyle defaultFont]
		ifFalse: [font].
	(emphasis == nil or: [emphasis = 0])
		ifTrue: [^ fontToUse]
		ifFalse: [^ fontToUse emphasized: emphasis]