initialize
	name := '(unnamed package)'.
	version := UVersion readFromString: '0'.
	category := self defaultCategory.
	depends := Set new.
	provides := Set new.
	description := ''.
	url := nil.
	homepage := nil.
	maintainer := ''