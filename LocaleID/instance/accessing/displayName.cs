displayName
	"Answer a proper name to represent the receiver in GUI. 
	 
	The wording is provided by translations of the magic value 
	'<language display name>'. 
	 
	'English' -> 'English'  
	'German' -> 'Deutsch'  
	"
	| magicPhrase translatedMagicPhrase |
	magicPhrase := '<language display name>'.
	translatedMagicPhrase := magicPhrase translatedTo: self.
	^ translatedMagicPhrase = magicPhrase
		ifTrue: [self displayLanguage]
		ifFalse: [translatedMagicPhrase]