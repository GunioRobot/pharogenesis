wantsBoldSelector
	"Only when a message selected, and not a class definition, hierarchy, or comment."

	^ (self messageListIndex ~= 0) and: [
		self setClassAndSelectorIn: [:class :selector | selector first isUppercase not]]