containingDirectory

	self splitName: directory to: [:parentPath :localName |
		^self copy directory: parentPath]