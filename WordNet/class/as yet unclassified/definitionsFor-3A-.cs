definitionsFor: aWord
	| aDef parts item |
	aDef _ self new.
	(aDef definition: aWord) ifNil:
		[self inform: 'Sorry, cannot reach the WordNet
web site; task abandoned.'.
		^ nil].
	parts _ aDef parts.
	parts size = 0 ifTrue:
		[self inform: 'Sorry, ', aWord, ' not found.'.
		^ nil].

	^ String streamContents:
		[:defStream |
			defStream nextPutAll: aWord; cr.
			parts do:
				[:aPart |
					defStream cr.
					1 to: (aDef sensesFor: aPart) do:
						[:senseNumber |
							defStream nextPutAll: aPart.
							item _ aDef def: senseNumber for: aPart.
							defStream nextPutAll: (' (', senseNumber printString, ') ', (item copyFrom: 2 to: item size - 1)).
							defStream cr]]]

"WordNet definitionsFor: 'balloon'"
