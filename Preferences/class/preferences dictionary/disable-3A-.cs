disable: preferenceNameSymbol
	"Shorthand access"
	self setPreference: preferenceNameSymbol toValue: false.
	self resetCategoryInfo "in case this call introduced a new pref"