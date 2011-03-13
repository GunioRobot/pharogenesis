drawNoseOn: aCanvas
	| nosePosition |
	nosePosition := self center * 2 + self lips center // 3.
	aCanvas fillOval: (nosePosition- (3@0) extent: 2 @ 2) color: Color black.
	aCanvas fillOval: (nosePosition + (3@0) extent: 2 @ 2) color: Color black