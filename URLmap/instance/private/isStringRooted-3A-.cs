isStringRooted: anUpperCasedString
	"check the string to see if it starts with something that makes it
lkely to be a rooted URL"
	^(anUpperCasedString indexOfSubCollection: 'HTTP' startingAt: 1) =
1 or:
	[(anUpperCasedString indexOfSubCollection: 'FTP' startingAt: 1) = 1 or:
	[(anUpperCasedString indexOfSubCollection: 'MAILTO' startingAt: 1)
= 1]]