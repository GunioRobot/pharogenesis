balloonTextForLexiconString
	"Answer suitable balloon text for the receiver thought of as an encoding (used in Lexicons) of the form
		<selector> <spaces> (<className>>)"

	| aComment contentsString aSelector aClassName |
	Preferences balloonHelpInMessageLists
		ifFalse: [^ nil].
	contentsString _ self contents asString.
	aSelector _ contentsString upTo: $ .
	aClassName _ contentsString copyFrom: ((contentsString indexOf: $() + 1) to: ((contentsString indexOf: $)) - 1).
	MessageSet parse: (aClassName, ' dummy') toClassAndSelector:
		[:cl :sel | cl ifNotNil:
			[aComment _ cl precodeCommentOrInheritedCommentFor: aSelector]].
	^ aComment
