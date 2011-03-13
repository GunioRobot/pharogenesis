asForm
	"Answer a Form made up of the bits that represent the receiver's displayable text."
	| theForm oldBackColor oldForeColor |
	textStyle isTTCStyle ifTrue: [
		theForm :=  (Form extent: compositionRectangle extent depth: 32)
		offset: offset.
	] ifFalse: [
		theForm := (ColorForm extent: compositionRectangle extent)
			offset: offset;
			colors: (Array
				with: (backColor == nil ifTrue: [Color transparent] ifFalse: [backColor])
				with: (foreColor == nil ifTrue: [Color black] ifFalse: [foreColor])).
	].
	oldBackColor := backColor.
	oldForeColor := foreColor.
	backColor := Color white.
	foreColor := Color black.
	self displayOn: theForm
		at: 0@0
		clippingBox: theForm boundingBox
		rule: Form over
		fillColor: nil.
	backColor := oldBackColor.
	foreColor := oldForeColor.
	^ theForm

"Example:
| p |
p := 'Abc' asParagraph.
p foregroundColor: Color red backgroundColor: Color black.
p asForm displayOn: Display at: 30@30 rule: Form over"
