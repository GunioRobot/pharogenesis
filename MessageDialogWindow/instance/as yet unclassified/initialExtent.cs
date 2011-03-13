initialExtent
	"Answer the initial extent for the receiver.
	Adjust the text if the text	would be wider than 1/4 the display width."
	
	|ext|
	ext := super initialExtent.
	self textMorph width > (Display width // 4) ifTrue: [
		self textMorph
			wrapFlag: true;
			hResizing: #rigid;
			extent: Display width // 4 @ 0.
		ext := super initialExtent].
	^ext