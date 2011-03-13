newFontPreviewInnerPanel 
	| sample i c f |
	sample := String new writeStream.
	f := model selectedFont.
	f isNil ifTrue:[^TextMorph new contents:''; yourself].
	f isSymbolFont
		ifFalse:[
			sample 
				nextPutAll: 'the quick brown fox jumps over the lazy dog' ;cr;
				nextPutAll:  'THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG.' ;cr].
	i := 0.
	33 to: 255 do:[:ci |
		sample nextPut: (c:=Character value: ci).
		i := i + 1.
		(('@Z`z' includes:c) or:[i = 30]) 
			ifTrue:[i :=0. sample cr]].
	sample := sample contents asText.
	"(f weightValue >= 700) ifTrue:[sample addAttribute: TextEmphasis bold].
	(f slantValue ~= 0) ifTrue:[sample addAttribute: TextEmphasis italic]."
	^TextMorph new 
		contents: sample;
		beAllFont: f;
		yourself