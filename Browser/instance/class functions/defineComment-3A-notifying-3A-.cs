defineComment: aString notifying: aController 
	"The receiver's textual content is a request to define a new comment for 
	the selected class. The comment is defined by the message expression, 
	aString. If any errors occur in evaluation, notify aController."

	| oldClass class |
	oldClass _ self selectedClassOrMetaClass.
	oldClass isNil ifTrue: [oldClass _ Object].
	class _ oldClass evaluatorClass
				evaluate: aString
				notifying: aController
				logged: true.
	(class isKindOf: Behavior)
		ifTrue: 
			[self unlock; editComment. ^true]
		ifFalse: [^false]