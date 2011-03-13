balloonTextForClassAndMethodString
	"Answer suitable balloon text for the receiver thought of as an encoding of the form
		<className>  [ class ] <selector>"

	| aComment |
	Preferences balloonHelpInMessageLists
		ifFalse: [^ nil].
	MessageSet parse: self contents asString toClassAndSelector:
		[:aClass :aSelector |
			(aClass notNil and: [aSelector notNil]) ifTrue:
				[aComment := aClass precodeCommentOrInheritedCommentFor: aSelector]].
	^ aComment
