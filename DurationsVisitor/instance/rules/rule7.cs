rule7
	"Rule 7: Unstressed shortening."

	word syllables
		do: [ :each |
			each stress > 0
				ifFalse: [each events do: [ :event | event phoneme isSyllabic ifTrue: [event stretch: 0.5]].
						each events first phoneme isSyllabic ifTrue: [each events first stretch: 0.7 / 0.5].
						(each events last phoneme isSyllabic and: [each events size > 1]) ifTrue: [each events last stretch: 0.7 / 0.5]]]
