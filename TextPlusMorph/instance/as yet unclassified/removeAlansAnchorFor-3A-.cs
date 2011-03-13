removeAlansAnchorFor: aMorph

	| anchors |

	anchors _ OrderedCollection new.
	text runs withStartStopAndValueDo: [:start :stop :attributes |
		attributes do: [:att |
			(att isMemberOf: TextAnchorPlus) ifTrue: [
				(att anchoredMorph isNil or: [
					att anchoredMorph == aMorph or: [att anchoredMorph world isNil]]) ifTrue: [
					anchors add: {att. start. stop}
				]
			]
		]
	].
	anchors do: [ :old |
		text removeAttribute: old first from: old second to: old third.
	].

