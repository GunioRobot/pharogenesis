parseCompositionMappingFrom: stream
"
	self halt.
	self parseCompositionMapping
"

	| line fieldEnd point fieldStart compositions toNumber diacritical result |

	toNumber _ [:quad | ('16r', quad) asNumber].

	Compositions _ IdentityDictionary new: 2048.
	Decompositions _ IdentityDictionary new: 2048.
	Diacriticals _ IdentitySet new: 2048.

	[(line _ stream upTo: Character cr) size > 0] whileTrue: [
		fieldEnd _ line indexOf: $; startingAt: 1.
		point _ ('16r', (line copyFrom: 1 to: fieldEnd - 1)) asNumber.
		2 to: 6 do: [:i |
			fieldStart _ fieldEnd + 1.
			fieldEnd _ line indexOf: $; startingAt: fieldStart.
		].
		compositions _ line copyFrom: fieldStart to: fieldEnd - 1.
		(compositions size > 0 and: [compositions first ~= $<]) ifTrue: [
			compositions _ compositions substrings collect: toNumber.
			compositions size > 1 ifTrue: [
				diacritical _ compositions first.
				Diacriticals add: diacritical.
				result _ compositions second.
				(Decompositions includesKey: point) ifTrue: [
					self error: 'should not happen'.
				] ifFalse: [
					Decompositions at: point put: (Array with: diacritical with: result).
				].
				(Compositions includesKey: diacritical) ifTrue: [
					(Compositions at: diacritical) at: result put: point.
				] ifFalse: [
					Compositions at: diacritical
						put: (IdentityDictionary new at: result put: point; yourself).
				].
			].
		].
	].
