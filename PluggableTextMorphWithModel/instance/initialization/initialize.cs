initialize
	super initialize.
	self on: self
		text: #getMyText
		accept: #setMyText:
		readSelection: nil
		menu: nil.
