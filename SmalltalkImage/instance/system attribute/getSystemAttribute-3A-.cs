getSystemAttribute: attributeID 
	"Optional. Answer the string for the system attribute with the given 
	integer ID. Answer nil if the given attribute is not defined on this 
	platform. On platforms that support invoking programs from command 
	lines (e.g., Unix), this mechanism can be used to pass command line 
	arguments to programs written in Squeak.

	By convention, the first command line argument that is not a VM
	configuration option is considered a 'document' to be filed in. Such a
	document can add methods and classes, can contain a serialized object,
	can include code to be executed, or any combination of these.

	Currently defined attributes include: 
	-1000...-1 - command line arguments that specify VM options 
	0 - the full path name for currently executing VM 
	(or, on some platforms, just the path name of the VM's directory) 
	1 - full path name of this image 
	2 - a Squeak document to open, if any 
	3...1000 - command line arguments for Squeak programs 
	1001 - this platform's operating system 
	1002 - operating system version 
	1003 - this platform's processor type
	1004 - vm version"

	<primitive: 149>
	^ nil