selfTestEquals: anIndexFileEntry
	"For testing and debugging purposes only, test whether the two entries are equivalent.  If you expect that IndexFileEntries should be identical, the use strict equality here.  Otherwise use approximate comparisons."

	"These should be exactly equal"
	#(messageFile msgID location from) do:
		[ :sel | ((self perform: sel) = (anIndexFileEntry perform: sel)) ifFalse: [ 
			Transcript cr.
			Transcript show: msgID printString, ' ', sel printString, ': ', (self perform: sel); cr.
			Transcript show: msgID printString, 'n', sel printString, ': ', (anIndexFileEntry perform: sel); cr.
]].

	"These should be comparably equal :-), typically varying only by white space"
	#(cc to subject) do:
		[ :sel | ((self comparableString: (self perform: sel)) =
				(self comparableString: (anIndexFileEntry perform: sel))) ifFalse: [
			Transcript cr.
			Transcript show: msgID printString, ' ', sel printString, ': ', (self perform: sel); cr.
			Transcript show: msgID printString, 'n', sel printString, ': ', (anIndexFileEntry perform: sel); cr.
]].

	"It could be that these are not absolutely identical, though they should be close"
	#(date time) do:
		[ :sel | (self perform: sel) = (anIndexFileEntry perform: sel) ifFalse:
					[Transcript cr;
						show: msgID printString, ' ', sel printString, ':', (self perform: sel) printString; cr]].

	[(self textLength - anIndexFileEntry textLength) abs <= 2] assert. 
