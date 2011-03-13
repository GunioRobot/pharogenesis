mapMacStringToPS: aString

	| copy val newVal |
	MacToPSCharacterMappings ifNil: [
		MacToPSCharacterMappings _ Array new: 256.
		self macToPSCharacterChart do: [ :pair |
			pair second = 999 ifFalse: [MacToPSCharacterMappings at: pair first put: pair second]
		].
	].
	copy _ aString copy.
	copy withIndexDo: [ :ch :index |
		(val _ ch asciiValue) > 127 ifTrue: [
			(newVal _ MacToPSCharacterMappings at: val) ifNotNil: [
				copy at: index put: newVal asCharacter
			].
		].
	].
	^copy