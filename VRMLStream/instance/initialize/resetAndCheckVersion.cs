resetAndCheckVersion
	"Check for #VRML V2.0 utf8"
	| version charSet char |
	self reset.
	"Check basic type of VRML file"
	'#VRML V' do:[:c| theStream next = c ifFalse:[^nil]].
	version := theStream next: 3.
	charSet := WriteStream on: String new.
	theStream next = Character space ifTrue:[
		[char := theStream next.
		char asciiValue = 32 or:[char asciiValue = 13 or:[char asciiValue =
10]]
		] whileFalse:[ charSet nextPut: char].
	].
	self reset.
	^Array with: version with: charSet contents.