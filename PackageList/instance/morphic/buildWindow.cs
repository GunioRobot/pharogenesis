buildWindow
	| window |
	window _ SystemWindow labelled: self label.
	window model: self.
	window addMorph: self buildList fullFrame: (LayoutFrame fractions: (0@0 corner: 1@1)).
	^ window