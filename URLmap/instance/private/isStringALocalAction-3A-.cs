isStringALocalAction: anUpperCasedString
	"check the string to see if it starts and end with  a shriek - code
for a Swiki action such as Comment or whatever"
	^(anUpperCasedString size >=2) and:
	[anUpperCasedString first = $! and:
	[anUpperCasedString last= $!]]