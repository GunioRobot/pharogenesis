testCompileValue
	self assertPragma: 'foo: true' givesKeyword: #foo: arguments: #( true ).
	self assertPragma: 'foo: false' givesKeyword: #foo: arguments: #( false ).
	self assertPragma: 'foo: nil' givesKeyword: #foo: arguments: #( nil ).
	
	self assertPragma: 'foo: String' givesKeyword: #foo: arguments: { String }.
	self assertPragma: 'foo: Pragma' givesKeyword: #foo: arguments: { Pragma }.