headerParagraph
	"Return a paragraph for the footer"
	| hPara rect |
	hPara := Paragraph new.
	hPara destinationForm: form.
	rect := (self in2pix: self textArea topLeft - (0.0@self headerHeight)) corner: 
				(self in2pix: self textArea topRight).
	hPara clippingRectangle: rect.
	hPara compositionRectangle: rect.
	^hPara