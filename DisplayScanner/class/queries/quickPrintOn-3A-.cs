quickPrintOn: aForm
	"Create an instance to print on the given form in the given rectangle."

	^(super new) quickPrintOn: aForm box: aForm boundingBox font: self defaultFont color: Color black