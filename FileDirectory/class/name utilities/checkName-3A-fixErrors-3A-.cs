checkName: fullName fixErrors: flag
	"Check a string aFileName for validity as a file name. Answer the original file name if it is valid. If the name is not valid (e.g., it is too long or contains illegal characters) and fixing is false, raise an error. If fixing is true, fix the name (usually by truncating and/or tranforming characters), and answer the corrected name. The default behavior is to truncate the name to 31 chars. Subclasses can do any kind of checking and correction appropriate to the underlying platform."

	^ DefaultDirectory
		checkName: (self localNameFor: fullName)
		fixErrors: flag
