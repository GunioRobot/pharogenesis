checkUntranslatedPhrase: phraseString 
	"check the phrase an aswer a string with a comment or a nil  
	meaning no-comments"

	(self translations includes: phraseString)
		ifTrue: [^ 'possible double-translation' translated].

	^ nil