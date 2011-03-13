labels: aString font: aFont lines: anArray
	"PopUpMenu allInstancesDo: [:x | x rescan]"
	| style paraForm inside labelPara |
	labelString _ aString.
	font _ aFont.
	style _ TextStyle fontArray: (Array with: font).
	style alignment: 2.  "centered"
	style gridForFont: 1 withLead: 0.
	lineArray _ anArray.
	labelPara _ Paragraph withText: aString asText style: style.
	paraForm _ labelPara asForm.
	form _ Form extent: paraForm extent + (4@4).
	form fillBlack.
	frame _ Quadrangle new.
	frame region: form boundingBox.
	frame borderWidth: 2.
	"Cheap drop shadow mask"
	"frame borderWidthLeft: 1 right: 3 top: 1 bottom: 3."
	paraForm displayOn: form at: frame inside topLeft.
	inside _ frame inside.
	lineArray == nil
	  ifFalse:
		[lineArray do:
			[:line |
			form fillBlack: (0 @ ((line * font height) + inside top) extent: (frame width @ 1))]].
	marker _ inside topLeft extent:
				inside width @ labelPara lineGrid.
	selection _ 1