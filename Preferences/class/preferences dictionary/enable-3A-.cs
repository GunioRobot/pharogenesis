enable: preferenceNameSymbol
	"Shorthand access"
	self setPreference: preferenceNameSymbol toValue: true.
	self resetCategoryInfo  "in case this call introduced a new pref"