isSelectorCharacter: aCharacter

	aCharacter isAlphaNumeric ifTrue: [^false].
	aCharacter isSeparator ifTrue:[^false].
	"$- is specified here as NOT being a selector char, but it can appear as the 
	first char in a binary selector. That case is handled specially elsewhere"
	(#( $" $# $$ $' $: $( $) $. $; $[ $] ${ $} $^ $_ $- ) includes: aCharacter) 
		ifTrue:[^false].
	aCharacter asciiValue = 30 ifTrue: [^false "the doIt char"].
	aCharacter asciiValue = 0 ifTrue: [^false].
	"Any other char is ok as a binary selector char."
	^true
