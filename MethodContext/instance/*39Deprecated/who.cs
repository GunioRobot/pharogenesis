who
	self deprecated: 'please use #methodClass and #selector'.
	
	self method ifNil: [^ #(unknown unkown)].
	^ {self methodClass . self selector}.
