asForm
	"Answer a Form made up of the bits that represent the receiver's displayable text."
	| theForm oldBackColor oldForeColor |
	textStyle isTTCStyle ifTrue: [
		theForm _  (Form extent: compositionRectangle extent depth: 32)
		offset: offset.
	] ifFalse: [
		theForm _ (ColorForm extent: compositionRectangle extent)
			offset: offset;
			colors: (Array
				with: (backColor == nil ifTrue: [Color transparent] ifFalse: [backColor])
				with: (foreColor == nil ifTrue: [Color black] ifFalse: [foreColor])).
	].
	oldBackColor _ backColor.
	oldForeColor _ foreColor.
	backColor _ Color white.
	foreColor _ Color black.
	self displayOn: theForm
		at: 0@0
		clippingBox: theForm boundingBox
		rule: Form over
		fillColor: nil.
	backColor _ oldBackColor.
	foreColor _ oldForeColor.
	^ theForm

"Example:
| p |
p _ 'Abc' asParagraph.
p foregroundColor: Color red backgroundColor: Color black.
p asForm displayOn: Display at: 30@30 rule: Form over"
