headersFor: obj withHash: hash
	"Create three header words for this object.  Length, class, header bits."
	"Three possibilities:
		Length, class, header bits
		0, class, header bits
		0,0, header bits"
	| header3 header2 header1 cix sizeFld |
	"3 gc bits"
	header1 _ 0.  "Mark, old, dirty"

	header1 _ header1 bitShift: 12.	"next fld is 12 bits"
	header1 _ header1 + (hash bitAnd: 16rFFF).

	header1 _ header1 bitShift: 5.
	sizeFld _ (self sizeInWordsOf: obj) + 1.	"size in long words, incl hdr0"
	cix _ compactClasses indexOf: obj class.	"0 means need full word"
	header2 _ self mapAt: obj class.
	header1 _ header1 + (cix bitAnd: 16r1F).

	header1 _ header1 bitShift: 4.
	header1 _ header1 + (self formatOf: obj).	"Class characteristics"

	header1 _ header1 bitShift: 6.
	sizeFld > 16r3F
		ifTrue: [header3 _ sizeFld bitShift: 2.
				sizeFld _ 0]
		ifFalse: [header3 _ 0].
	header1 _ header1 + sizeFld.

	header1 _ header1 bitShift: 2.

	header3 > 0 ifTrue:
		["3-word: type=0"
		^ Array with: header3+0 with: header2+0 with: header1+0].
	cix = 0 ifTrue:
		[ "2-word: type=1"
		^ Array with: header2+1 with: header1+1].
	"1-word: type=3"
	^ Array with: header1+3