scanFrom: strm
	"Read the style section of a fileOut or sources file.  nextChunk has already been done.  We need to return a RunArray of TextAttributes of various kinds.  These are written by the implementors of writeScanOn:"
	| rr vv aa this |
	(strm peekFor: $( ) ifFalse: [^ nil].
	rr _ OrderedCollection new.
	[strm skipSeparators.
	 strm peekFor: $)] whileFalse: 
		[rr add: (Number readFrom: strm)].
	vv _ OrderedCollection new.	"Value array"
	aa _ OrderedCollection new.	"Attributes list"
	[(this _ strm next) == nil] whileFalse: [
		this == $, ifTrue: [vv add: aa asArray.  aa _ OrderedCollection new].
		this == $a ifTrue: [aa add: 
			(TextAlignment new alignment: (Integer readFrom: strm))].
		this == $f ifTrue: [aa add: 
			(TextFontChange new fontNumber: (Integer readFrom: strm))].
		this == $F ifTrue: [aa add: (TextFontReference toFont: 
			(StrikeFont familyName: (strm upTo: $#) size: (Integer readFrom: strm)))].
		this == $b ifTrue: [aa add: (TextEmphasis bold)].
		this == $i ifTrue: [aa add: (TextEmphasis italic)].
		this == $u ifTrue: [aa add: (TextEmphasis underlined)].
		this == $= ifTrue: [aa add: (TextEmphasis struckOut)].
		this == $n ifTrue: [aa add: (TextEmphasis normal)].
		this == $- ifTrue: [aa add: (TextKern kern: -1)].
		this == $+ ifTrue: [aa add: (TextKern kern: 1)].
		this == $c ifTrue: [aa add: (TextColor scanFrom: strm)]. "color"
		this == $L ifTrue: [aa add: (TextLink scanFrom: strm)].	"L not look like 1"
		this == $R ifTrue: [aa add: (TextURL scanFrom: strm)].
				"R capitalized so it can follow a number"
		this == $q ifTrue: [aa add: (TextSqkPageLink scanFrom: strm)].
		this == $p ifTrue: [aa add: (TextSqkProjectLink scanFrom: strm)].
		this == $P ifTrue: [aa add: (TextPrintIt scanFrom: strm)].
		this == $d ifTrue: [aa add: (TextDoIt scanFrom: strm)].
		"space, cr do nothing"
		].
	aa size > 0 ifTrue: [vv add: aa asArray].
	^ self runs: rr asArray values: vv asArray
"
RunArray scanFrom: (ReadStream on: '(14 50 312)f1,f1b,f1LInteger +;i')
"