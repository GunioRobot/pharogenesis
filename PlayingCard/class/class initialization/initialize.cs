initialize
	"PlayingCard initialize"
	"Read the stored forms from mime-encoded data in imageData."
	| forms f |
	f := Base64MimeConverter
				mimeDecodeToBytes: (ReadStream on: self imageData).
	forms := OrderedCollection new.
	f next = 2
		ifFalse: [self error: 'corrupted imageData' translated].
	[f atEnd]
		whileFalse: [forms
				add: (Form new readFrom: f)].
	"1/2 image of Kc, Qc, Jc, ... d, h, s, and center image of As"
	FaceForms := forms copyFrom: 1 to: 13.
	"Images of small club, smaller club (for face cards), large club (for 
	2-10, A), 
	followed by 3 more each for diamonds, heardt, spaces, all as 1-bit 
	forms. "
	SuitForms := forms copyFrom: 14 to: 25.
	"Images of A, 2, 3 ... J, Q, K as 1-bit forms"
	NumberForms := forms copyFrom: 26 to: 38.
	CardSize := 71 @ 96.
	FaceLoc := 12 @ 11.
	NumberLoc := 2 @ 4.
	SuitLoc := 3 @ 18.
	FaceSuitLoc := 2 @ 18.
	TopSpotLocs := {{}. {28 @ 10}. {28 @ 10}. {15 @ 10. 41 @ 10}. {15 @ 10. 41 @ 10}. {14 @ 10. 42 @ 10}. {14 @ 10. 42 @ 10}. {14 @ 10. 28 @ 26. 42 @ 10}. {14 @ 10. 14 @ 30. 42 @ 10. 42 @ 30}. {14 @ 10. 14 @ 30. 42 @ 10. 42 @ 30. 28 @ 21}}.
	"A"
	"2"
	"3"
	"4"
	"5"
	"6"
	"7"
	"8"
	"9"
	"10"
	MidSpotLocs := {{28 @ 40}. {}. {28 @ 40}. {}. {28 @ 40}. {14 @ 40. 42 @ 40}. {14 @ 40. 42 @ 40. 28 @ 26}. {14 @ 40. 42 @ 40}. {28 @ 40}. {}}.
	"A"
	"2"
	"3"
	"4"
	"5"
	"6"
	"7"
	"8"
	"9"
	"10"
	ASpadesLoc := 16 @ 27