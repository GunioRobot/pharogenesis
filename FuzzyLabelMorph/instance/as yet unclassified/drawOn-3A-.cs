drawOn: aCanvas
	"Draw based on enablement."
	
	|pc fuzzColor labelColor|
	pc := self paneColor.
	labelColor := self enabled
		ifTrue: [self color]
		ifFalse: [pc twiceDarker].
	fuzzColor := self enabled
		ifTrue: [labelColor twiceDarker darker contrastingColor alpha: self alpha]
		ifFalse: [Color transparent].
	aCanvas depth < 8 ifTrue: [fuzzColor := Color transparent].
	aCanvas
		drawString: self contents
		in: (self bounds translateBy: 0@-1)
		font: self fontToUse
		color: fuzzColor;
		drawString: self contents
		in: (self bounds translateBy: (self offset * 2)@-1)
		font: self fontToUse
		color: fuzzColor;
		drawString: self contents
		in: (self bounds translateBy: (self offset * 2)@(self offset * 2 - 1))
		font: self fontToUse
		color: fuzzColor;
		drawString: self contents
		in: (self bounds translateBy: 0@(self offset * 2 - 1))
		font: self fontToUse
		color: fuzzColor;
		drawString: self contents
		in: (self bounds translateBy: self offset@(self offset - 1))
		font: self fontToUse
		color: labelColor