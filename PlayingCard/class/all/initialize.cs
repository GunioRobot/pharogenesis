initialize  "PlayingCard initialize"
	| forms f |
	"Read the stored forms from mime-encoded data in imageData."
	f _ Base64MimeConverter mimeDecodeToBytes: (ReadStream on: self imageData).
	forms _ OrderedCollection new.
	f next = 2 ifFalse: [self error: 'corrupted imageData'].
	[f atEnd] whileFalse: [forms add: (Form new readFrom: f)].

	"1/2 image of Kc, Qc, Jc, ... d, h, s, and center image of As"
	FaceForms _ forms copyFrom: 1 to: 13.
	"Images of small club, smaller club (for face cards), large club (for 2-10, A),
	followed by 3 more each for diamonds, heardt, spaces, all as 1-bit forms."
	SuitForms _ forms copyFrom: 14 to: 25.
	"Images of A, 2, 3 ... J, Q, K as 1-bit forms"
	NumberForms _ forms copyFrom: 26 to: 38.
	CardSize _ 71@96.
	FaceLoc _ 12@11.
	NumberLoc _ 2@4.
	SuitLoc _ 3@18.
	FaceSuitLoc _ 2@18.
	TopSpotLocs _ {{}.  "A"
				{28@10}.  "2"
				{28@10}.  "3"
				{15@10. 41@10}.  "4"
				{15@10. 41@10}.  "5"
				{14@10. 42@10}.  "6"
				{14@10. 42@10}.  "7"
				{14@10. 28@26. 42@10}.  "8"
				{14@10. 14@30. 42@10. 42@30}.  "9"
				{14@10. 14@30. 42@10. 42@30. 28@21}}.   "10"
	MidSpotLocs _ {{28@40}.  "A"
				{}.  "2"
				{28@40}.  "3"
				{}.  "4"
				{28@40}.  "5"
				{14@40. 42@40}.  "6"
				{14@40. 42@40. 28@26}.  "7"
				{14@40. 42@40}.  "8"
				{28@40}.  "9"
				{}  "10"}.
	ASpadesLoc _ 16@27.
	"self class removeSelector: #imageData"  "Can save space"
"
	NOTE:  If you wish to save this class with new data,
	be sure to execute this doit before fileOut.  It will generate the method, #imageData
	| rws mimeData | 
	rws _ ReadWriteStream on: (ByteArray new: 18000).
	rws nextPut: 2.
	FaceForms , SuitForms , NumberForms do: [:f | f writeOn: rws].
	mimeData _ (Base64MimeConverter mimeEncode: rws) contents.
	PlayingCard class compile: 'imageData ^ ' , mimeData printString classified: 'all'
"