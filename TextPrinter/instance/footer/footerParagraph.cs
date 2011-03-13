footerParagraph
	"Return a paragraph for the footer"
	| fPara rect |
	fPara := Paragraph new.
	fPara destinationForm: form.
	rect := (self in2pix: self textArea bottomLeft) corner: 
				(self in2pix: self textArea bottomRight + (0.0@self footerHeight)).
	fPara clippingRectangle: rect.
	fPara compositionRectangle: rect.
	^fPara