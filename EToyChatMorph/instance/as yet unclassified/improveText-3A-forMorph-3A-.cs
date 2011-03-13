improveText: someText forMorph: aMorph

	| betterText conversions newAttr fontForAll |

	fontForAll _ aMorph eToyGetMainFont.
	betterText _ someText veryDeepCopy.
	conversions _ OrderedCollection new.
	betterText runs withStartStopAndValueDo: [:start :stop :attributes |
		attributes do: [:att |
			(att isMemberOf: TextFontChange) ifTrue: [
				conversions add: {att. start. stop}
			]
		]
	].
	conversions do: [ :old |
		betterText removeAttribute: old first from: old second to: old third.
		newAttr _ TextFontReference toFont: (fontForAll fontAt: old first fontNumber).
		newAttr fontNumber: old first fontNumber.
		betterText addAttribute: newAttr from: old second to: old third.
	].
	^betterText