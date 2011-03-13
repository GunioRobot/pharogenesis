readCedarAndKayaPics
	"Read in the pictures of Cedar and Kaya for the demo."
	"EToySystem readCedarAndKayaPics"
	"CedarPic display. KayaPic display"

	| f1 f2 |
	f1 _ Smalltalk gifReaderClass formFromFileNamed: 'cedar1.gif'.
	f2 _ Form extent: f1 extent depth: 16.
	f1 displayOn: f2 at: 0@0 rule: Form paint.
	self formDictionary at: 'CedarPic' put: f2.
	f1 _ Smalltalk gifReaderClass formFromFileNamed: 'kaya1.gif'.
	f2 _ Form extent: f1 extent depth: 16.
	f1 displayOn: f2 at: 0@0 rule: Form paint.
	self formDictionary at: 'KayaPic' put: f2.
