checkSpanishPhrase: phraseString translation: translationString 
	"check the translation an aswer a string with a comment or a  
	nil meaning no-comments"
	| superResult |
	superResult := self checkPhrase: phraseString translation: translationString.

	superResult isNil
		ifFalse: [^ superResult].
"For some reason, MCInstaller couldn't read Spanish character."
"	((translationString withBlanksTrimmed includes: $?)
			and: [(translationString withBlanksTrimmed includes: $é) not])
		ifTrue: [^ 'éOlvidÆ§ el signo de pregunta?'].
	((translationString withBlanksTrimmed includes: $!)
			and: [(translationString withBlanksTrimmed includes: $éÄ) not])
		ifTrue: [^ 'éOlvidÆ§ el signo de admiraciÆ§n?'].
"
	^ nil