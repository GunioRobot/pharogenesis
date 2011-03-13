allJumpEndStrings

	| answer |

	answer _ OrderedCollection new.
	text runs withStartStopAndValueDo: [:start :stop :attributes |
		attributes do: [:att |
			(att isMemberOf: TextPlusJumpEnd) ifTrue: [
				(answer includes: att jumpLabel) ifFalse: [answer add: att jumpLabel].
			]
		]
	].
	^answer

