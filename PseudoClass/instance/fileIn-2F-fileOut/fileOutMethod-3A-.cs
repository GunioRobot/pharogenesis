fileOutMethod: selector
	| f |
	f := (FileStream newFileNamed: self name,'-', selector, '.st').
	self fileOutMethods: (Array with: selector)
			on: f.
	f close