newLabelMorph: aStringOrMorph
	"Answer a new label morph with the given label text."

	|m l|
	l := aStringOrMorph isMorph
		ifTrue: [aStringOrMorph lock]
		ifFalse: [LabelMorph new
				contents: aStringOrMorph;
				font: self font;
				vResizing: #shrinkWrap;
				hResizing: #shrinkWrap;
				lock].
	m := TabLabelMorph new
		roundedCorners: #(1 4);
		cornerStyle: self cornerStyle;
		changeTableLayout;
		listCentering: #center;
		layoutInset: (self theme tabLabelInsetFor: self);
		hResizing: #shrinkWrap;
		vResizing: #spaceFill;
		addMorph: l.
	m on: #mouseDown send: #tabClicked:with: to: self.
	^m