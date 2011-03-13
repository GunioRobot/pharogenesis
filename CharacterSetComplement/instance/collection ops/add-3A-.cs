add: aCharacter
	"a character is present if not absent"
	
	(absent includes: aCharacter) ifTrue: [absent remove: aCharacter].
	^aCharacter