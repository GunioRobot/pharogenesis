labels: aString font: aFont lines: anArray

	| style inside |
	labelString _ aString.
	font _ aFont.
	lineArray _ anArray.
	frame _ Quadrangle new.
	frame region: self menuForm boundingBox.
	frame borderWidth: 2.
	inside _ frame inside.
	marker _ inside topLeft extent: (inside width @ self computeLabelParagraph lineGrid).
	selection _ 1.