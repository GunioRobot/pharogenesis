valueOfHtmlEntity: specialEntity 
	"Please note: the 'min: 255' is a crude fix to silently ignore unicode characters."

	(specialEntity beginsWith: '#')
		ifTrue:
			[^ ((specialEntity
				copyFrom: 2
				to: specialEntity size) asNumber min: 255) asCharacter isoToSqueak].
	^ HtmlEntities at: specialEntity ifAbsent: [nil]