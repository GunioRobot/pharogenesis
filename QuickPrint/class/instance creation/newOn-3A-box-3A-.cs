newOn: aForm box: aRectangle
	"Create an instance to print on the given form in the given rectangle."

	^(super new) newOn: aForm box: aRectangle font: self defaultFont color: Color black