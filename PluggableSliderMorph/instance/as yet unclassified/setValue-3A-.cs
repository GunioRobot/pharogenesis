setValue: newValue
	"Called internally for propagation to model."

	|scaled|
	value := newValue.
	self scaledValue: (scaled := self scaledValue).
	self model ifNotNil: [
		self setValueSelector ifNotNilDo: [:sel |
			self model perform: sel with: scaled]]