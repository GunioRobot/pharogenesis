privateLoadFrom: srcObject
	| color |
	color _ srcObject asColor.
	self red: color red.
	self green: color green.
	self blue: color blue.
	self alpha: color alpha.