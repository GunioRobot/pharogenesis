stripMethods: tripletList messageCode: messageString
	"Used to 'cap' methods that need to be protected for proprietary reasons, etc.; call this with a list of triplets of symbols of the form  (<class name>  <#instance or #class> <selector name>), and with a string to be produced as part of the error msg if any of the methods affected is reached"

	self deprecated: 'Use SmalltalkImage current stripMethods: tripletList messageCode: messageString'.
	SmalltalkImage current stripMethods: tripletList messageCode: messageString