image: aForm at: aPoint sourceRect: sourceRect rule: rule 
	self gsave; translate:aPoint + self origin.
	target write:aForm.
	self grestore.
