fontNumberAt: characterIndex 
	"Answer the fontNumber for characters in the run beginning at characterIndex."
	| attributes fontNumber |
	self size = 0 ifTrue: [^1].	"null text tolerates access"
	attributes _ runs at: characterIndex.
	fontNumber _ 1.
	attributes do: [:att | (att isMemberOf: TextFontChange) ifTrue: [fontNumber _ att fontNumber]].
	^ fontNumber
	