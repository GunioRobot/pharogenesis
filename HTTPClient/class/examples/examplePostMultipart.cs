examplePostMultipart
	"HTTPClient examplePostMultipart"

	| args result |
	args _ Dictionary new.
	args
		at: 'arg1' put: #('val1');
		at: 'arg2' put: #('val2');
		yourself.
	result _ HTTPClient httpPostMultipart: 'http://www.squeaklet.com/cgi-bin/thrd.pl'  args: args.
	Transcript show: result content; cr; cr.

